using System.Collections.Generic;
using System.Linq;
using System;
using Proteus.Domain.Foundation;
using Linq.Specifications;

namespace AltNetSample.Domain
{
    public class CustomerAddressChangeRule : QuerySpecification<Address>
    {
        //address must be 'complete' to be assigned to a customer
        public override bool IsSatisfiedBy(Address candidate)
        {
            return !string.IsNullOrEmpty(candidate.City)
                && !string.IsNullOrEmpty(candidate.PostalCode)
                && !string.IsNullOrEmpty(candidate.Streetname) &&
                !string.IsNullOrEmpty(candidate.StreetNumber)
                && candidate.State != null;

        }

    }
}
