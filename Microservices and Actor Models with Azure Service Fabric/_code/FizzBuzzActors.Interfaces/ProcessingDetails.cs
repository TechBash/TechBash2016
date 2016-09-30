using System.Runtime.Serialization;

namespace FizzBuzzActors.Interfaces
{
    [DataContract]
    public class ProcessingDetails
    {
        [DataMember]
        public int LowerBound { get; set; }

        [DataMember]
        public int UpperBound { get; set; }

        [DataMember]
        public int WorkerCount { get; set; }

        protected ProcessingDetails()
        { }


        public ProcessingDetails(int lowerBound, int upperBound, int workerCount)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
            WorkerCount = workerCount;
        }
    }
}