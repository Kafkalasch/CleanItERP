using System.Collections.Generic;
using System.Linq;
using CleanItERP.DataModel;
using CleanItERP.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CleanItERP.Services
{
    public class ListOrdersService : IListOrdersService
    {
        private CleanItERPContext Context { get; }

        public ListOrdersService(CleanItERPContext context){
            this.Context = context;
        }

        public IEnumerable<OrderDto> GetOrdersForBranch(int branchId){
            var orders = QueryOrdersWithIncludedNavigationProps()
                            .Where(o => o.BranchId == branchId);
            var dtos = ConvertToDtos(orders);
            return dtos;
        }

        public IEnumerable<OrderDto> GetCollectableOrdersForBranch(int branchId){
            var ordersFilteredByBranch = QueryOrdersWithIncludedNavigationProps()
                            .Where(o => o.BranchId == branchId)
                            .Where(o => o.DateReturned == null);
            var cleanedDtos = ConvertToDtos(ordersFilteredByBranch)
                            .Where(o => o.Textiles.All(t => t.TextileState == DatabaseConstants.TextileState.FINISHED));
            
            return cleanedDtos;
        }

        private IQueryable<Order> QueryOrdersWithIncludedNavigationProps(){
            return Context.Orders
                            .Include(o => o.Branch)
                            .Include(o => o.Clerk)
                            .Include(o => o.Customer)
                            .Include(o => o.Textiles);
        }

        private IEnumerable<OrderDto> ConvertToDtos(IEnumerable<Order> orders){
            var dtos = new List<OrderDto>();
            foreach(var order in orders.ToList()){
                dtos.Add(order.ToDto(Context));
            }
            return dtos;
        }

    }
}