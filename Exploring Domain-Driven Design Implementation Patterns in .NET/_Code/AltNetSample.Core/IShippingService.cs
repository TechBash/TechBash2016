
namespace AltNetSample.Domain
{
    public interface IShippingService
    {
        ShippingResult ShipOrder(Customer customer, Order order, Destination destination);
        ShippingResult CancelShipping(Order order);
    }
}
