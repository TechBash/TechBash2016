using Proteus.Domain.Foundation;
using System.Linq;
using Linq.Specifications;
using System.Linq.Expressions;

namespace AltNetSample.Domain
{
    public class CustomerIsFromStateRule : QuerySpecification<Customer>
    {
        private State _state;

        /// <summary>
        /// Initializes a new instance of the CustomerIsFromStateRule class.
        /// </summary>
        /// <param name="state"></param>
        public CustomerIsFromStateRule(State state)
        {
            _state = state;
        }

        public override bool IsSatisfiedBy(Customer candidate)
        {
            return (candidate.Address.State == _state);
        }
    }
}
