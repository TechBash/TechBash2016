using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace FizzBuzzActors.Interfaces
{
    public interface IFizzBuzzEvaluator : IActor
    {
        Task<FizzBuzzResult> EvaluateInput(Input input);
    }
}