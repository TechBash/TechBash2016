using AltNetSample.Domain;

namespace AltNetSample.Infrastructure
{
    public class AirFreightShipper : IShippingService
    {
        public ShippingResult ShipOrder(Customer customer, Order order, Destination destination)
        {
            throw new System.NotImplementedException();
        }

        public ShippingResult CancelShipping(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
