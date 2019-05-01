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
    public class TextileTypeController : ControllerBase
    {
        private ITextileTypeListService Service { get; }
        public TextileTypeController(ITextileTypeListService service)
        {
            this.Service = service;
        }

        [HttpGet("All")]
        public ActionResult<IEnumerable<TextileType>> GetAllTextileTypes()
        {
            return Service.GetTextileTypes().ToList();
        }

    }
}
