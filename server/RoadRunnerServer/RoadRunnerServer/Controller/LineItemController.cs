using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RoadRunnerServer.Shared;

namespace RoadRunnerServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineItemController : ControllerBase
    {
        private readonly ILineService _lineService;

        public LineItemController(ILineService lineService)
        {
            _lineService = lineService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Product> GetLineItems()
        {
            return _lineService.GetCustomerOrder();
        }

        [HttpGet]   
        [Route("GetLastUpdateTime")]
        public long GetLastUpdateTime()
        {
            return _lineService.GetLastUpdateTime();
        }
    }
}