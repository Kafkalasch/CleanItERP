using System.Collections.Generic;
using CleanItERP.DataModel;
using CleanItERP.DTOs;

namespace CleanItERP.Services
{
    public interface IOrderListService
    {
        IEnumerable<OrderDto> GetOrdersForBranch(int branchId);

        IEnumerable<OrderDto> GetFinishedOrdersForBranch(int branchId);
    }
}