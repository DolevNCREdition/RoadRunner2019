using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoadRunnerServer.Services;

namespace RoadRunnerServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyboardController : ControllerBase
    {
        private ILineService _lineService;

        public KeyboardController(ILineService lineService)
        {
            _lineService = lineService;
        }

        [HttpPost]
        public bool AddProductById(int id)
        {
            return _lineService.AddLineItem(id);
        }
    }
}