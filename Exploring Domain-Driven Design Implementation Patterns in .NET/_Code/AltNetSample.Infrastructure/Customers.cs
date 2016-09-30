using System.Collections.Generic;
using AltNetSample.Domain;
using System;
using System.Linq;

namespace AltNetSample.Infrastructure
{

    public class Customers : MemoryRepository<Customer>, ICustomerRepository
    {
        public void AddCustomer(Customer customer)
        {
            Save(customer);
        }

        public void AddCustomers(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                AddCustomer(customer);
            }
        }

        public void ChangeCustomer(Customer customer)
        {
            Save(customer);
        }

        public IEnumerable<Customer> FromState(State state)
        {
            var criteria = new CustomerIsFromStateRule(state);
            return FindAll(criteria).AsEnumerable();
        }

        public IEnumerable<Customer> OverCreditLimit()
        {
            //rely upon the OverCreditLimitCriteria to filter the customers
            
            //do some data access in here; return statement just to satisfy the compiler
            return new List<Customer>();
        }

        public void RemoveCustomer(Customer customer)
        {
            //delete customer here
        }

        public void RemoveCustomers(IEnumerable<Customer> customers)
        {
            //delete customers here
        }

        public IEnumerable<Customer> WithOutstandingOrders()
        {
            var criteria = new CustomerHasAtLeastOneOutstandingOrderRule();
            return FindAll(criteria).AsEnumerable();
        }

    }
}