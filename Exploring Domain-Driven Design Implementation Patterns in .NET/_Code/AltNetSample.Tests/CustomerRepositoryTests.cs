using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AltNetSample.Infrastructure;
using AltNetSample.Domain;

namespace AltNetSample.Tests
{
    [TestFixture]
    public class CustomerRepositoryTests
    {
        [Test]
        public void Can_Get_Customers_By_State()
        {
            //new repository
            ICustomerRepository customers = new Customers();
            
            
            //a state that *is* NY
            var ny = new State("New York", "ny");
            
            //an address in NY
            var nyAddress = new Address("1", "Main Street", "New York", ny, "12345");

            //a state *not* NY
            var notNy = new State("New Jersey", "nj");
            
            //an address *not* in NY
            var notNyAddress = new Address("1", "Main Street", "Trenton", notNy, "12345");

            //a customer not in NY
            var notNyCustomer1 = new Customer();
            notNyCustomer1.ChangeAddress(notNyAddress);

            //a customer in NY
            var nyCustomer1 = new Customer();
            nyCustomer1.ChangeAddress(nyAddress);

            //another customer in NY
            var nyCustomer2 = new Customer();
            nyCustomer2.ChangeAddress(nyAddress);

            //still one more customer in NY
            var nyCustomer3 = new Customer();
            nyCustomer3.ChangeAddress(nyAddress);

            //add all the customers to the repository
            customers.AddCustomer(nyCustomer1);
            customers.AddCustomer(nyCustomer2);
            customers.AddCustomer(nyCustomer3);
            customers.AddCustomer(notNyCustomer1);

            //select customers from the state that is NY
            var results = customers.FromState(ny);

            Assert.That(results, Has.Member(nyCustomer1));
            Assert.That(results, Has.Member(nyCustomer2));
            Assert.That(results, Has.Member(nyCustomer3));
            Assert.That(results.Count(), Is.EqualTo(3));
            Assert.That(results, Has.No.Member(notNyCustomer1));
        }
    }
}
