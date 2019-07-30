using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoadRunnerServer.Models;

namespace RoadRunnerServer.Services
{
    public class LineService : ILineService
    {
        private IProductService _productService;

        public LineService(IProductService productService)
        {
            _productService = productService;
        }

        private List<Product> _lineItems = new List<Product>();

        public List<Product> LineItems { get => _lineItems; }

        public bool AddLineItem(int productId)
        {
            var product = _productService.GetProduct(productId);
            if (product == null)
            {
                return false;
            }
            _lineItems.Add(product);
            return true;
        }

        public void CloseTransaction()
        {
            _lineItems.Clear();
        }
    }
}
