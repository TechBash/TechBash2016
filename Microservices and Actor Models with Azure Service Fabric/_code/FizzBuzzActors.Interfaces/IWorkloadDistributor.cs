using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace FizzBuzzActors.Interfaces
{
    public interface IWorkloadDistributor :IActor
    {
        Task StartProcessingWork(ProcessingDetails details);
    }
}