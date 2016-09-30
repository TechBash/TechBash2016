using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzzActors.Interfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace FizzBuzzActors
{
    public class ApplicationEntryPoint : Actor, IApplicationEntryPoint
    {
        private IList<FizzBuzzResult> _results;

        protected override async Task OnActivateAsync()
        {
            _results = await StateManager.GetOrAddStateAsync("results", new List<FizzBuzzResult>());
            await base.OnActivateAsync();
        }

        protected override async Task OnPreActorMethodAsync(ActorMethodContext actorMethodContext)
        {
            _results = await StateManager.GetOrAddStateAsync("results", new List<FizzBuzzResult>());
            await base.OnPreActorMethodAsync(actorMethodContext);
        }

        protected override async Task OnPostActorMethodAsync(ActorMethodContext actorMethodContext)
        {
            await StateManager.SetStateAsync("results", _results);
            await base.OnPostActorMethodAsync(actorMethodContext);
        }

        public async Task DoWork(ProcessingDetails details)
        {
            ResetResults();

            var distributor = ActorProxy.Create<IWorkloadDistributor>(new ActorId(FizzBuzzActorIdentity.Distributor));
            await distributor.StartProcessingWork(details);
        }

        public async Task ReportResult(FizzBuzzResult result)
        {
            _results.Add(result);
            await Task.Delay(0);
        }

        public Task<IEnumerable<FizzBuzzResult>> GetAllResults()
        {
            return Task.FromResult(_results.AsEnumerable());
        }

        private void ResetResults()
        {
            _results.Clear();
        }
    }
}