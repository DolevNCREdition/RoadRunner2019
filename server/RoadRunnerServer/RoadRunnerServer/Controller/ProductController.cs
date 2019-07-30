using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RoadRunnerServer.Shared.Interfaces;
using RoadRunnerServer.Shared.Models;

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
        //https://localhost:44380/api/Product/3
        public ActionResult<Product> GetProduct(int id)
        {

            return _productService.GetProduct(id);
        }

        [HttpGet]
        //https://localhost:44380/api/Product/
        public ActionResult<IList<Product>> GetAllProducts()
        {
            return Ok( _productService.GetAllProducts());
        }
    }
}