using Microsoft.AspNetCore.Mvc;
using RoadRunnerServer.Shared;

namespace RoadRunnerServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PLUController : ControllerBase
    {
        private readonly ILineService _lineService;

        public PLUController(ILineService lineService)
        {
            _lineService = lineService;
        }

        [HttpPost]
        public bool AddProductById(int id)
        {
            return _lineService.AppendLine(id);
        }
    }
}