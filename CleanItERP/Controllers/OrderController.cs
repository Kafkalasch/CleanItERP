using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanItERP.Services;
using CleanItERP.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CleanItERP.DTOs;

namespace CleanItERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderListService OrderListService { get; }
        public OrderController(IOrderListService orderListService)
        {
            this.OrderListService = orderListService;
        }

        [HttpGet("ForBranch/{branchId}")]
        public ActionResult<IEnumerable<OrderDto>> GetOrdersForBranch(int branchId)
        {
            return OrderListService.GetOrdersForBranch(branchId).ToList();
        }

        [HttpGet("FinishedOrdersForBranch/{branchId}")]
        public ActionResult<IEnumerable<OrderDto>> GetFinishedOrdersForBranch(int branchId)
        {
            return OrderListService.GetFinishedOrdersForBranch(branchId).ToList();
        }

    }
}
