using System;
using System.Collections.Generic;
using System.Linq;

namespace AltNetSample.Domain
{
    public class OrderItem : Proteus.Domain.Foundation.IdentityPersistenceBase<OrderItem, int>
    {
        private string _description;

        private int _quantity;

        public string Description
        {
            get { return _description; }
        }

        public void DescribeItemAs(string description)
        {
            if (!string.IsNullOrEmpty(description))
                _description = description;
        }

        public int Id
        {
            get { return _persistenceId; }
        }

        public int Quantity
        {
            get { return _quantity; }
        }

        public void IncreaseQuantityBy(int quantity)
        {
            if (quantity >= 0)
                _quantity += quantity;
        }

    }
}
