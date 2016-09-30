using System;
using System.Collections.Generic;
using System.Linq;

namespace AltNetSample.Domain
{
    public class Order : Proteus.Domain.Foundation.IdentityPersistenceBase<Order, int>
    {
        private IList<OrderItem> _items;

        private DateTime _orderDate;

        private OrderStatus _status;

        /// <summary>
        /// Initializes a new instance of the Order class.
        /// </summary>
        public Order()
        {
            _items = new List<OrderItem>();
        }

        public bool CanBeAddedToCustomer
        {
            /*
             * implemented as a property so...
             * a) reads better in code
             * b) temptation to pass args in is reduced!
             * ('CanBeAdded' is a 'state' of the object so 'property' semantics)
             */
            get { return new CanAddOrderRule().IsSatisfiedBy(this); }
        }

        public int Id
        {
            get { return _persistenceId; }
        }

//          Don't expose unless we absolutely have to do so!
//        public IEnumerable<OrderItem> Items
//        {
//            get { return _items.AsEnumerable(); }
//        }

        public DateTime OrderDate
        {
            get { return _orderDate; }
            set
            {
                _orderDate = value;
            }
        }

        public OrderStatus Status
        {
            get { return _status; }
        }

        public void AddItem(OrderItem item)
        {
            //we can use .Contains in the next statement b/c of identity-value-equality!
            if (!_items.Contains(item))
                _items.Add(item);
            else
            {
                //.Single() call is safe here b/c we tested .Contains() earlier!
                var existingItem = _items.Where(i => i == item).Single();
                existingItem.IncreaseQuantityBy(item.Quantity);
            }

        }

        public bool HasAtLeastOneItem
        {
            get { return _items.Count > 0; }

        }


        public void Cancel()
        {
            _status = OrderStatus.Cancelled;
        }

    }
}
