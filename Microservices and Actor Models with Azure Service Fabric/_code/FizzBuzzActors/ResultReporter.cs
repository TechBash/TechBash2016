using System;
using System.Threading.Tasks;
using FizzBuzzActors.Interfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace FizzBuzzActors
{
    [StatePersistence(StatePersistence.None)]
    public class ResultReporter : Actor, IResultReporter
    {
        public async Task ReportResult(FizzBuzzResult result)
        {
            ActorEventSource.Current.Message($"Input: {result.Input} | Result: {result.Output}");

            var entryPoint = ActorProxy.Create<IApplicationEntryPoint>(new ActorId(FizzBuzzActorIdentity.EntryPoint));
            await entryPoint.ReportResult(result);
        }
    }
}