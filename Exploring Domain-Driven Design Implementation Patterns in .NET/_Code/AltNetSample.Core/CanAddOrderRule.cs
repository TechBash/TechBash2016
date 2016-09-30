using Proteus.Domain.Foundation;
using System.Linq;
using System;
using Linq.Specifications;
using System.Linq.Expressions;

namespace AltNetSample.Domain
{
    public class CanAddOrderRule : QuerySpecification<Order>
    {
        private static readonly OutstandingOrderRule _outstandingOrderRule = new OutstandingOrderRule();

        public override bool IsSatisfiedBy(Order candidate)
        {
            // NOT candidate.Status == OrderStatus.Open <-- since we have the other spec, let's USE it!
            return candidate.HasAtLeastOneItem && _outstandingOrderRule.IsSatisfiedBy(candidate);
                
            /*
             *extend this method later as business rules for what makes an order OK 
             * to add increase in complexity
             */
        }
    }
}
