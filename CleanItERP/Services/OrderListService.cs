using System.Collections.Generic;
using System.Linq;
using CleanItERP.DataModel;
using CleanItERP.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CleanItERP.Services
{
    public class OrderListService : IOrderListService
    {
        private CleanItERPContext Context { get; }

        public OrderListService(CleanItERPContext context){
            this.Context = context;
        }

        public IEnumerable<OrderDto> GetOrdersForBranch(int branchId){
            var dtos = new List<OrderDto>();
            var orders = Context.Orders
                            .Include(o => o.Branch)
                            .Include(o => o.Clerk)
                            .Include(o => o.Customer)
                            .Include(o => o.Textiles)
                            .Where(o => o.BranchId == branchId)
                            .ToList();
            foreach(var order in orders){
                dtos.Add(order.ToDto(Context));
            }
            return dtos;
        }

    }
}