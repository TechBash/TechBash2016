using System;
using System.Runtime.Serialization;

namespace AltNetSample.Domain
{
    public class AddressChangeFailure : Exception
    {
        public AddressChangeFailure(string message, Exception innerException)
            : base(message, innerException) { }

        public AddressChangeFailure(string message)
            : base(message) { }

        protected AddressChangeFailure(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        public AddressChangeFailure() { }

        public Address AttemptedAddress { get; set; }

    }
}
