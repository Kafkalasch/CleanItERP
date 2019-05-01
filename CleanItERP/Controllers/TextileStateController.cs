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
    public class TextileStateController : ControllerBase
    {
        private ITextileStateListService Service { get; }
        public TextileStateController(ITextileStateListService service)
        {
            this.Service = service;
        }

        [HttpGet("All")]
        public ActionResult<IEnumerable<TextileState>> GetAllTextileStates()
        {
            return Service.GetTextileStates().ToList();
        }

    }
}
