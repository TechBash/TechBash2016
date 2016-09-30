using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace FizzBuzzActors.Interfaces
{
    public interface IResultReporter :IActor
    {
        Task ReportResult(FizzBuzzResult result);
    }
}