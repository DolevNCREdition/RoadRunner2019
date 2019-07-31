using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoadRunnerServer.Services;
using RoadRunnerServer.Shared.Models;

namespace RoadRunnerServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineItemController : ControllerBase
    {
        private ILineService _lineService;

        public LineItemController(ILineService lineService)
        {
            _lineService = lineService;
        }

        [HttpGet]
        public IEnumerable<Product> GetLineItems()
        {
            return _lineService.GetCustomerOrder();
        }
    }
}