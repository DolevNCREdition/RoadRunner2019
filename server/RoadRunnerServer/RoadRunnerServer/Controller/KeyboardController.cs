using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoadRunnerServer.Shared;

namespace RoadRunnerServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyboardController : ControllerBase
    {
        private readonly ILineService _lineService;

        public KeyboardController(ILineService lineService)
        {
            _lineService = lineService;
        }

        [HttpPost]
        public async Task<bool> AddProductById(int id)
        {
            return await _lineService.AppendLineAsync(id);
        }
    }
}