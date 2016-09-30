using System.Runtime.Serialization;

namespace FizzBuzzActors.Interfaces
{
    [DataContract]
    public class Input
    {
        [DataMember]
        public int Value { get; set; }

        protected Input()
        { }

        public Input(int value)
        {
            Value = value;
        }
    }
}