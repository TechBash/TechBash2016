using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using FizzBuzzActors.Interfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace FizzBuzzActors
{
    [StatePersistence(StatePersistence.None)]
    public class FizzBuzzEvaluator : Actor, IFizzBuzzEvaluator
    {
        private Random _random;

        protected override async Task OnActivateAsync()
        {
            _random = await StateManager.GetOrAddStateAsync("random-generator", new Random(DateTime.Now.Millisecond));
            await base.OnActivateAsync();
        }

        protected override async Task OnPreActorMethodAsync(ActorMethodContext actorMethodContext)
        {
            _random = await StateManager.GetOrAddStateAsync("random-generator", new Random(DateTime.Now.Millisecond));
            await base.OnPreActorMethodAsync(actorMethodContext);
        }

        protected override async Task OnPostActorMethodAsync(ActorMethodContext actorMethodContext)
        {
            await StateManager.SetStateAsync("random-generator", _random);
            await base.OnPostActorMethodAsync(actorMethodContext);
        }

        public async Task<FizzBuzzResult> EvaluateInput(Input input)
        {
            await SimulateIntensiveProcessingLoad();

            var result = input.Value.ToString();

            if (input.Value % 15 == 0)
            {
                result = "FizzBuzz";
            }

            else if (input.Value % 3 == 0)
            {
                result = "Fizz";
            }

            else if (input.Value % 5 == 0)
            {
                result = "Buzz";
            }

            ActorEventSource.Current.Message($"Actor {this.GetActorId()} calculated result '{result}' for input '{input.Value}'");
            
            return await Task.FromResult(new FizzBuzzResult(input.Value, result));
        }

        private async Task SimulateIntensiveProcessingLoad()
        {
            await Task.Delay(_random.Next(100, 500));
            //await Task.Delay(500);
        }
    }
}
