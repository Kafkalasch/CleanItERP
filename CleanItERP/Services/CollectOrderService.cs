using System;
using CleanItERP.DataModel;
using CleanItERP.Services.Exceptions;

namespace CleanItERP.Services
{
    public class CollectOrderService : ICollectOrderService
    {
        private CleanItERPContext Context { get; }
        public CollectOrderService(CleanItERPContext context)
        {
            this.Context = context;
        }

        public void CollectOrder(int orderId)
        {
            var order = this.Context.Orders.Find(orderId);
            if(order == null)
                throw EntityNotFoundException.CreateOrderNotFoundException(orderId);
            if(order.DateReturned != null)
                throw OrderHasAlreadyBeenCollectedException.CreateExceptionForOrder(order);

            order.DateReturned = DateTime.Now;
            Context.SaveChanges();
        }
    }
}