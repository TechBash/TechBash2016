using System;
using System.Diagnostics;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FizzBuzzActors.Interfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace FizzBuzzActors
{
    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            try
            {
                ActorRuntime.RegisterActorAsync<ApplicationEntryPoint>().GetAwaiter().GetResult();
                ActorRuntime.RegisterActorAsync<WorkloadDistributor>().GetAwaiter().GetResult();
                ActorRuntime.RegisterActorAsync<FizzBuzzEvaluator>().GetAwaiter().GetResult();
                ActorRuntime.RegisterActorAsync<ResultReporter>().GetAwaiter().GetResult();

                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ActorEventSource.Current.ActorHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
