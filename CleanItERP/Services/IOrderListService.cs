using System.Collections.Generic;
using CleanItERP.DataModel;
using CleanItERP.DTOs;

namespace CleanItERP.Services
{
    public interface IOrderListService
    {
        IEnumerable<OrderDto> GetAllOrders();
    }
}