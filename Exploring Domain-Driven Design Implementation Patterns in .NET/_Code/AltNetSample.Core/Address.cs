using System;
using Proteus.Domain.Foundation;

namespace AltNetSample.Domain
{
    public class Address : ValueObjectBase<Address>
    {
        private readonly string _city;

        private readonly string _postalCode;

        private readonly State _state;

        private readonly string _streetname;

        private readonly string _streetNumber;

        /*
         * Extremely naive constructor implementation...
         * Who can tell me why?
         */
        public Address(string streetNumber, string streetname, string city, State state, string postalCode)
        {
            _city = city;
            _postalCode = postalCode;
            _state = state;
            _streetname = streetname;
            _streetNumber = streetNumber;
        }

        public string City
        {
            get { return _city; }
        }

        public string PostalCode
        {
            get { return _postalCode; }
        }

        public State State
        {
            get { return _state; }
        }

        public string Streetname
        {
            get { return _streetname; }
        }

        public string StreetNumber
        {
            get { return _streetNumber; }
        }

        public Address ChangeStreetNumber(string newNumber)
        {
            return new Address(newNumber, Streetname, City, State, PostalCode);
        }

        public Address ChangeStreetName(string newName)
        {
            return new Address(StreetNumber, newName, City, State, PostalCode);
        }

        public Address ChangeLocation(string newCity, State newState, string newPostalCode)
        {
            return new Address(StreetNumber, Streetname, newCity, newState, newPostalCode);
        }

    }
}
