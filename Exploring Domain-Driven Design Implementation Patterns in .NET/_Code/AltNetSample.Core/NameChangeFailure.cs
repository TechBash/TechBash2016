using System;
using System.Runtime.Serialization;

namespace AltNetSample.Domain
{
    public class NameChangeFailure : Exception
    {
        protected NameChangeFailure(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        public NameChangeFailure(string message, Exception innerException)
            : base(message, innerException) { }

        public NameChangeFailure(string message) : base(message) { }

        public NameChangeFailure() { }

        public Name AttemptedName { get; set; }
    }
}
