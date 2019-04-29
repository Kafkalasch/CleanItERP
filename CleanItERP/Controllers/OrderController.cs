using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanItERP.BusinessModel;
using CleanItERP.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CleanItERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderManager OrderManager { get; }
        public OrderController(IOrderManager orderManager)
        {
            this.OrderManager = orderManager;
        }

        [HttpGet("Orders")]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return OrderManager.GetOrders().ToList();
        }

    }
}
