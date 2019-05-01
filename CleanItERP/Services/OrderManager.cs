using System.Collections.Generic;
using CleanItERP.DataModel;

namespace CleanItERP.Services
{
    public class OrderManager : IOrderManager
    {
        private CleanItERPContext Context { get; }

        public OrderManager(CleanItERPContext context){
            this.Context = context;
        }

        public IEnumerable<Order> GetOrders(){
            return Context.Orders;
        }

    }
}