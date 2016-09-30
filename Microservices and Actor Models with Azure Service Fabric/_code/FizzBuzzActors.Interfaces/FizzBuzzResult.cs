using System.Runtime.Serialization;

namespace FizzBuzzActors.Interfaces
{
    [DataContract]
    public class FizzBuzzResult
    {
        [DataMember]
        public string Output { get; set; }

        [DataMember]
        public int Input { get; set; }

        protected FizzBuzzResult()
        { }

        public FizzBuzzResult(int input, string output)
        {
            Output = output;
            Input = input;
        }

        public override string ToString()
        {
            return $"Input: {Input} | Output: {Output}";
        }
    }
}