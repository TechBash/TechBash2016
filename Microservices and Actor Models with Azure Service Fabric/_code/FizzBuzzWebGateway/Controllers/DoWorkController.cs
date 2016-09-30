using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using FizzBuzzActors.Interfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;

namespace FizzBuzzWebGateway.Controllers
{
    public class DoWorkController : ApiController
    {
        public string Get()
        {
            return "Correct Usage is /api/DoWork/?lowerBound=1&upperBound=100&workerCount=5";
        }

        public async Task<IEnumerable<string>> Get(int lowerBound, int upperBound, int workerCount)
        {
            var entryPoint = ActorProxy.Create<IApplicationEntryPoint>(new ActorId(FizzBuzzActorIdentity.EntryPoint));

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            await entryPoint.DoWork(new ProcessingDetails(lowerBound, upperBound, workerCount));
            var results = await entryPoint.GetAllResults();

            stopwatch.Stop();

            var output = new List<string>();
            var orderedResults = results.OrderBy(result => result.Input);

            output.Add($"RESULTS SUMMARY: Calculated {orderedResults.Count()} results in {stopwatch.Elapsed.TotalSeconds} seconds by {workerCount} worker(s).");
            output.AddRange(orderedResults.Select(result => result.ToString()));

            return output;
        }


    }
}
