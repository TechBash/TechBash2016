using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FizzBuzzActors.Interfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace FizzBuzzActors
{
    [StatePersistence(StatePersistence.Persisted)]
    public class WorkloadDistributor : Actor, IWorkloadDistributor
    {

        private IList<IFizzBuzzEvaluator> _workers;

        protected override async Task OnActivateAsync()
        {
            _workers = await StateManager.GetOrAddStateAsync("workers", new List<IFizzBuzzEvaluator>());
            await base.OnActivateAsync();
        }

        protected override async Task OnPreActorMethodAsync(ActorMethodContext actorMethodContext)
        {
            _workers = await StateManager.GetOrAddStateAsync("workers", new List<IFizzBuzzEvaluator>());
            await base.OnPreActorMethodAsync(actorMethodContext);
        }

        protected override async Task OnPostActorMethodAsync(ActorMethodContext actorMethodContext)
        {
            await StateManager.SetStateAsync("workers", _workers);
            await base.OnPostActorMethodAsync(actorMethodContext);
        }

        public async Task StartProcessingWork(ProcessingDetails details)
        {
            ResetWorkers();
            CreateWorkers(details.WorkerCount);
            await DistributeWork(details.LowerBound, details.UpperBound);
        }

        private async Task DistributeWork(int lowerBound, int upperBound)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var tasks = new List<Task<FizzBuzzResult>>();

            for (int input = lowerBound; input <= upperBound;)
            {
                //get a random index into the collection of workers
                var workerIndex = random.Next(0, _workers.Count);

                //retrieve a random worker from the pool
                var worker = _workers[workerIndex];
                ActorEventSource.Current.Message($"Sending Input: '{input}' to Worker: {worker.GetActorId()}");

                //assign iterator to loop-local variable to avoid closure issues in lambda for Task invocation
                var copyOfInput = input;
                tasks.Add(Task.Run(() => worker.EvaluateInput(new Input(copyOfInput))));

                input++;
            }

            ReportAllWorkDispatched();

            var results = await Task.WhenAll(tasks);

            //need to await here in order for the ETW logs to have a change to spit out full diagnostics before the
            // outer-most request completes (no reason for this line in a non-demo scenario)
            await Task.Delay(100);

            foreach (var result in results)
            {
                await ReportResult(result);
            }

        }

        private void ResetWorkers()
        {
            _workers = new List<IFizzBuzzEvaluator>();
        }


        private void ReportAllWorkDispatched()
        {
            ActorEventSource.Current.Message("*** ALL WORK DISPATCHED ***");
        }

        private async Task ReportResult(FizzBuzzResult result)
        {
            var reporter = ActorProxy.Create<IResultReporter>(new ActorId(FizzBuzzActorIdentity.Reporter));
            await reporter.ReportResult(result);
        }

        private void CreateWorkers(int workerCount)
        {
            //create worker actors; name them incrementally using a 1-based suffix
            for (var i = 1; i < workerCount + 1; i++)
            {
                _workers.Add(ActorProxy.Create<IFizzBuzzEvaluator>(new ActorId($"{FizzBuzzActorIdentity.Evaluator}{i}")));
            }
        }
    }
}