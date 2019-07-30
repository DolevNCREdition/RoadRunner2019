using Microsoft.AspNetCore.Mvc;
using RoadRunnerServer.Shared.Models;
using RoadRunnerServer.Services.Interfaces;

namespace RoadRunnerServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return _productService.GetProduct(id);
        }
    }
}