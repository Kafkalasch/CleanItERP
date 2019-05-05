using System.Collections.Generic;
using CleanItERP.DataModel;
using CleanItERP.DTOs;

namespace CleanItERP.Services
{
    public interface IListOrdersService
    {
        IEnumerable<OrderDto> GetOrdersForBranch(int branchId);

        IEnumerable<OrderDto> GetCollectableOrdersForBranch(int branchId);
    }
}