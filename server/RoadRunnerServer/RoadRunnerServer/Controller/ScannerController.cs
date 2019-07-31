using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoadRunnerServer.Shared;

namespace RoadRunnerServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScannerController : ControllerBase
    {
        private readonly ILineService _lineService;

        public ScannerController(ILineService lineService)
        {
            _lineService = lineService;
        }

        [HttpPost("{id}")]
        public async Task<bool> AddProductById(int id)
        {
            return await _lineService.AppendLineAsync(id);
        }
    }
}