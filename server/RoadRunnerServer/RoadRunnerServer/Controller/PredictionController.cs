using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoadRunnerServer.Models;
using RoadRunnerServer.Services;

namespace RoadRunnerServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        private ILineService _lineService;

        public PredictionController(ILineService lineService)
        {
            _lineService = lineService;
        }

        [HttpGet]
        public List<Product> GetPrediction()
        {
            return null;
        }
    }
}