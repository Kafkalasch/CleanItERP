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
    public class BranchController : ControllerBase
    {
        private IListBranchesService Service { get; }
        public BranchController(IListBranchesService service)
        {
            this.Service = service;
        }

        [HttpGet("All")]
        public ActionResult<IEnumerable<BranchDto>> GetAllBranches()
        {
            return Service.GetBranches().ToList();
        }

    }
}
