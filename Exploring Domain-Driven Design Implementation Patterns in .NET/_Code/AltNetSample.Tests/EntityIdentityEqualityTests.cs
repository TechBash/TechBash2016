using System;
using NUnit.Framework;
using AltNetSample.Domain;
using Proteus.Utility.UnitTest;

namespace AltNetSample.Tests
{

    public class EntityIdentityEqualityTests
    {
        [TestFixture]
        public class When_Identity_Is_Same_And_Other_Values_are_Defaults : UnitTestBase
        {
            [Test]
            public void Entities_Are_Equal()
            {
                Customer customer = new Customer();
                Customer otherCustomer = new Customer();

                SetInstanceFieldValue(customer, "_persistenceId", 1);
                SetInstanceFieldValue(otherCustomer, "_persistenceId", 1);

                Assert.That(customer, Is.EqualTo(otherCustomer));
            }
        }

        [TestFixture]
        public class When_Identity_Is_Same_But_Property_Values_Differ : UnitTestBase
        {
            [Test]
            public void Entities_Are_Equal()
            {
                Customer customer = new Customer();
                Name name = new Name("Steve", "Bohlen");
                SetInstanceFieldValue(customer, "_persistenceId", 1);
                customer.ChangeName(name);

                Customer otherCustomer = new Customer();
                Name differentName = new Name(String.Format("{0}_DIFFERENT", customer.Firstname), String.Format("{0}_DIFFERENT", customer.Lastname));
                SetInstanceFieldValue(otherCustomer, "_persistenceId", 1);
                otherCustomer.ChangeName(differentName);

                Assert.That(customer, Is.EqualTo(otherCustomer));
            }
        }

    }
}
