using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanItERP.Services;
using CleanItERP.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CleanItERP.DTOs;
using CleanItERP.Services.Exceptions;
using Microsoft.AspNetCore.Http;

namespace CleanItERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        [HttpGet("ForBranch/{branchId}")]
        public ActionResult<IEnumerable<OrderDto>> GetOrdersForBranch(int branchId, [FromServices] IListOrdersService service)
        {
            return service.GetOrdersForBranch(branchId).ToList();
        }

        [HttpGet("FinishedOrdersForBranch/{branchId}")]
        public ActionResult<IEnumerable<OrderDto>> GetFinishedOrdersForBranch(int branchId, [FromServices] IListOrdersService service)
        {
            return service.GetFinishedOrdersForBranch(branchId).ToList();
        }

        [HttpPatch("CollectOrder/{orderId}")]
        public IActionResult CollectOrder(int orderId, [FromServices] ICollectOrderService service)
        {
            try
            {
                service.CollectOrder(orderId);
                return Ok();
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e);
            }
            catch (OrderHasAlreadyBeenCollectedException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

    }
}
