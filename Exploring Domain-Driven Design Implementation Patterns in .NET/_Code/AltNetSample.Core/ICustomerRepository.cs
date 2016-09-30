using System.Collections.Generic;
using System;
using Proteus.Domain.Foundation;
using Linq.Specifications;
using System.Linq;

namespace AltNetSample.Domain
{

    public interface ICustomerRepository
    {
        void RemoveCustomers(IEnumerable<Customer> customers);
        void RemoveCustomer(Customer customer);
        void AddCustomers(IEnumerable<Customer> customers);
        void ChangeCustomer(Customer customer);
        void AddCustomer(Customer customer);
        IEnumerable<Customer> FromState(State state);
        IEnumerable<Customer> WithOutstandingOrders();
    }
}
