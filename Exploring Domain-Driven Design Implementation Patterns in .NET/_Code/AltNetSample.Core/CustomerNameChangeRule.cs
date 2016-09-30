using System.Collections.Generic;
using System.Linq;
using System;
using Proteus.Domain.Foundation;
using Linq.Specifications;

namespace AltNetSample.Domain
{
    public class CustomerNameChangeRule : QuerySpecification<Name>
    {
        //this constraint says "lastname" is required but (perhaps) firstname can be blank
        public override bool IsSatisfiedBy(Name candidate)
        {
            return !string.IsNullOrEmpty(candidate.Lastname);
        }
    }
}
