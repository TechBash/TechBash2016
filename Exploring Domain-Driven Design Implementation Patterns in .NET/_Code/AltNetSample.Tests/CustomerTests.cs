using System;
using AltNetSample.Domain;
using NUnit.Framework;

namespace AltNetSample.Tests
{

    public class CustomerTests
    {
        [TestFixture]
        public class When_New_Name_Is_Valid_To_Change
        {
            private Customer _customer;
            private Name _validName;
            private const string VALID_FIRSTNAME = "John";
            private const string VALID_LASTNAME = "Doe";

            [SetUp]
            public void _TestSetUp()
            {
                _validName = new Name(VALID_FIRSTNAME, VALID_LASTNAME);
                _customer = new Customer();
            }

            [Test]
            public void CanAssignNameToCustomer()
            {
                _customer.ChangeName(_validName);

                Assert.That(_customer.Firstname, Is.EqualTo(VALID_FIRSTNAME));
                Assert.That(_customer.Lastname, Is.EqualTo(VALID_LASTNAME));
            }
        }

        public class When_Name_Is_Not_Valid_To_Change
        {
            private Customer _customer;
            private Name _invaldName;

            private const string VALID_FIRSTNAME = "John";
            private const string INVALID_LASTNAME = null;

            [SetUp]
            public void _TestSetUp()
            {
                _invaldName = new Name(VALID_FIRSTNAME, INVALID_LASTNAME);
                _customer = new Customer();
            }

            [Test]
            public void CannotAssignNameToCustomer()
            {
                Assert.Throws<NameChangeFailure>(() => _customer.ChangeName(_invaldName));
            }

            [Test]
            public void Invalid_Name_Is_Available_To_Inspect()
            {
                try
                {
                    _customer.ChangeName(_invaldName);
                }
                catch (NameChangeFailure failure)
                {
                    Assert.That(failure.AttemptedName, Is.SameAs(_invaldName));
                }
            }

        }


    }
}