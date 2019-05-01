using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanItERP.Services;
using CleanItERP.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CleanItERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private IBranchListService Service { get; }
        public BranchController(IBranchListService service)
        {
            this.Service = service;
        }

        [HttpGet("All")]
        public ActionResult<IEnumerable<Branch>> GetAllBranches()
        {
            return Service.GetBranches().ToList();
        }

    }
}
