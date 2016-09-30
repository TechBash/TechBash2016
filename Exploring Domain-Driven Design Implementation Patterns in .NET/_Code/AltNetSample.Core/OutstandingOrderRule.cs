using Proteus.Domain.Foundation;
using System.Linq;
using Linq.Specifications;
using System.Linq.Expressions;

namespace AltNetSample.Domain
{
    public class OutstandingOrderRule : QuerySpecification<Order>
    {
        public override bool IsSatisfiedBy(Order candidate)
        {
            return (candidate.Status == OrderStatus.Open);
        }
    }
}