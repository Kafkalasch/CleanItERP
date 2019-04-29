using System.Collections.Generic;
using CleanItERP.DataModel;

namespace CleanItERP.BusinessModel
{
    public interface IOrderManager
    {
        IEnumerable<Order> GetOrders();
    }
}