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
        private IOrderListService OrderManager { get; }
        public OrderController(IOrderListService orderManager)
        {
            this.OrderManager = orderManager;
        }

        [HttpGet("ForBranch/{branchId}")]
        public ActionResult<IEnumerable<OrderDto>> GetOrdersForBranch(int branchId)
        {
            return OrderManager.GetOrdersForBranch(branchId).ToList();
        }

    }
}
