using System.Collections.Generic;
using CleanItERP.DataModel;

namespace CleanItERP.Services
{
    public interface IOrderManager
    {
        IEnumerable<Order> GetOrders();
    }
}