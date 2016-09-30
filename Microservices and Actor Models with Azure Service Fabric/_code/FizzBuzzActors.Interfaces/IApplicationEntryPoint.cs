using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace FizzBuzzActors.Interfaces
{
    public interface IApplicationEntryPoint : IActor
    {
        Task DoWork(ProcessingDetails details);
        Task ReportResult(FizzBuzzResult result);
        Task<IEnumerable<FizzBuzzResult>> GetAllResults();
    }
}