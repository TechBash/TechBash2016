using System.Collections.Generic;
using System.Linq;
using System;
using Proteus.Domain.Foundation;

namespace AltNetSample.Domain
{
    public class Customer : IdentityPersistenceBase<Customer, int>
    {
        private Name _name;
        
        private Address _address;
        
        private IList<Order> _orders;

        /// <summary>
        /// Initializes a new instance of the Customer class.
        /// </summary>
        public Customer()
        {
            _orders = new List<Order>();
        }

        public Address Address
        {
            get { return _address; }
        }
        public string Firstname
        {
            get { return _name.Firstname; }
        }

        public int Id
        {
            get { return _persistenceId; }
        }

        public string Lastname
        {
            get { return _name.Lastname; }
        }

        public IEnumerable<Order> OrdersNotCancelled
        {
            get { return _orders.Where(o => o.Status != OrderStatus.Cancelled).AsEnumerable(); }
        }

        public void AddOrder(Order order)
        {
            /*
             * _NOT_
             * if (order.Items.Count() == 0)
             *   throw new AddOrderOperationException("An order cannot be added without having any Items!");
             *   
             * Customer class should have no knowledge of how an order determines its valid to be added!
             */

            if (order.CanBeAddedToCustomer)
                _orders.Add(order);
            else
                /*
                 *the thing _performing_ the action decides how to react when can't do the op 
                 * and _NOT_ the thing being asked if its OK
                 */
                throw new AddOrderFailure("Could not add order!") { AttemptedOrder = order };
        }

        public void CancelOrder(Order order)
        {
            //we can use .Contains in the next statement b/c of identity-value-equality!
            if (_orders.Contains(order))
            {
                /*
                 * because of identity-value-equality ensured among entities,
                 * we don't have to write this next statement as...
                 * var orderToCancel = _orders.Where(o => o.Id == order.Id).Single();
                 */
                var orderToCancel = _orders.Where(o => o == order).Single();

                /*
                 * HOLLYWOOD principle: don't call us, we'll call you! (tell, don't ask)
                 * _NOT_ orderToCancel.Status = OrderStatus.Cancelled;
                 */
                orderToCancel.Cancel();
            }
        }

        //allows the parent to 'report' on the state of its collection
        // rather than expose the collection to the outside world
        public bool HasOrder(Order order)
        {
            return _orders.Contains(order);
        }

        public void ChangeName(string firstname, string lastname)
        {
            //delegate the job to the underlying object;
            //  customer should have no idea how to actually process the values in a name!
            var proposedName = _name.ChangeName(firstname, lastname);

            if (new CustomerNameChangeRule().IsSatisfiedBy(proposedName))
                _name = proposedName;
            else
                throw new NameChangeFailure("Cannot change name!") { AttemptedName = proposedName };
        }

        public void ChangeName(Name name)
        {
            if (new CustomerNameChangeRule().IsSatisfiedBy(name))
                _name = name;
            else
                throw new NameChangeFailure("Cannot change name!") { AttemptedName = name };
        }

        public void ChangeAddress(Address newAddress)
        {
            if (new CustomerAddressChangeRule().IsSatisfiedBy(newAddress))
                _address = newAddress;
            else
                throw new AddressChangeFailure("Cannot change Address!") { AttemptedAddress = newAddress };

        }
    }
}