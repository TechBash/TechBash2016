
namespace AltNetSample.Domain
{
    public class Destination : Address
    {

        /// <summary>
        /// Initializes a new instance of the Destination class.
        /// </summary>
        public Destination(string streetNumber, string streetName, string city, State state, string postalCode)
            : base(streetNumber, streetName, city, state, postalCode)
        {
        }

    }
}
