using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoadRunnerServer.Services;
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
        public bool AddProductById(int id)
        {
            return _lineService.AppendLine(id);
        }
    }
}