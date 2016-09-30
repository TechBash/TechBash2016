using System;
using System.Runtime.Serialization;

namespace AltNetSample.Domain
{
    public class AddOrderFailure : Exception
    {
        public AddOrderFailure() { }

        protected AddOrderFailure(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        public AddOrderFailure(string message, Exception innerException)
            : base(message, innerException) { }

        public AddOrderFailure(string message) : base(message) { }

        public object AttemptedOrder { get; set; }

    }
}