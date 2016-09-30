using System.Collections.Generic;
using System;
using Proteus.Domain.Foundation;

namespace AltNetSample.Domain
{
    public class State : ValueObjectBase<State>
    {
        /// <summary>
        /// Initializes a new instance of the State class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="abbreviation"></param>
        public State(string name, string abbreviation)
        {
            _abbreviation = abbreviation;
            _name = name;
        }

        private readonly string _abbreviation;

        private readonly string _name;

        public string Abbreviation
        {
            get
            {
                return _abbreviation;
            }
        }

        public string Name
        {
            get { return _name; }
        }

    }
}
