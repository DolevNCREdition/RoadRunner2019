﻿using System;
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
    public class PLUController : ControllerBase
    {
        private ILineService _lineService;

        public PLUController(ILineService lineService)
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