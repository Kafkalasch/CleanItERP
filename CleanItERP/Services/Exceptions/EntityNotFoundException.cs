using System;
namespace CleanItERP.Services.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        private EntityNotFoundException(String msg) : base(msg) { }

        public static EntityNotFoundException CreateOrderNotFoundException(int orderId){
            return new EntityNotFoundException($"Did not find an order with id '{orderId}'");
        }
    }
}