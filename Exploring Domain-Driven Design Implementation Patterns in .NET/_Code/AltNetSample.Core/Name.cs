using System.Collections.Generic;
using System.Linq;
using System;
using Proteus.Domain.Foundation;

namespace AltNetSample.Domain
{
    public class Name : ValueObjectBase<Name>
    {
        private readonly string _firstname;

        private readonly string _lastname;

        /// <summary>
        /// Initializes a new instance of the Name class.
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        public Name(string firstname, string lastname)
        {
            _firstname = firstname;
            _lastname = lastname;
        }

        public string Firstname
        {
            get { return _firstname; }
        }

        public string Lastname
        {
            get { return _lastname; }
        }

        public Name ChangeName(string newFirstname, string newLastname)
        {
            return new Name(newFirstname, newLastname);
        }

    }
}
