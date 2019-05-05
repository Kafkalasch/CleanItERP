using System.Diagnostics;
using System;
using CleanItERP.DataModel;

namespace CleanItERP.Services.Exceptions
{
    public class OrderHasAlreadyBeenCollectedException : Exception
    {
        private OrderHasAlreadyBeenCollectedException(String msg) : base(msg) {}

        public static OrderHasAlreadyBeenCollectedException CreateExceptionForOrder(Order order){
            Debug.Assert(order.DateReturned != null);

            return new OrderHasAlreadyBeenCollectedException(
                $"The Order {order.Identifier} has already been collected on {order.DateReturned}. An order cannot be collected twice.");
        }

    }
}