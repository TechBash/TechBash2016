using AltNetSample.Domain;

namespace AltNetSample.Infrastructure
{
    public class GroundShipper : IShippingService
    {
        public ShippingResult CancelShipping(Order order)
        {
            //do something to cancel the shipping of the order
            //question to consider: should the order *really* be cancelled too...?
            order.Cancel();

            return ShippingResult.Cancelled;
        }

        public ShippingResult ShipOrder(Customer customer, Order order, Destination destination)
        {
            //can only ship via ground to the customer's own address
            if (new GroundShippingApprovalRule(destination).IsSatisfiedBy(customer))
                //do something here with customer, order, and destination
                return ShippingResult.Success;
            else
                return ShippingResult.Failure;
        }

    }
}