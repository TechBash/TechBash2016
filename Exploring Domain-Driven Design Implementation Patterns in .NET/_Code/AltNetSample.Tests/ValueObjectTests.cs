using NUnit.Framework;
using AltNetSample.Domain;

namespace AltNetSample.Tests
{
    
    public class ValueObjectBaseTests
    {
        [TestFixture]
        public class When_Comparing_ValueObjectBases_With_Equal_Properties
        {
            [Test]
            public void Instances_Are_Equal()
            {
                Address address = new Address("123", "Main Street", "Anywhere", new State("SomeState", "SS"), "12345");
                Address otherAddress = new Address(address.StreetNumber, address.Streetname, address.City, address.State, address.PostalCode);

                Assert.That(address, Is.EqualTo(otherAddress));
            }    
        }

        [TestFixture]
        public class When_Comparing_ValueObjectBases_With_Unequal_Properties
        {
            [Test]
            public void Instances_Are_Unequal()
            {
                Address address = new Address("123", "Main Street", "Anywhere", new State("SomeState", "SS"), "12345");
                Address otherAddress = new Address(address.StreetNumber, string.Format("{0}_DIFFERENT",address.Streetname), address.City, address.State, address.PostalCode);

                Assert.That(address, Is.Not.EqualTo(otherAddress));
            }
        }


        




    }
}
