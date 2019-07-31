using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoadRunnerServer.Services.Interfaces;
using RoadRunnerServer.Shared.Interfaces;
using RoadRunnerServer.Shared.Models;

namespace RoadRunnerServer.Services
{
    public class LineService : ILineService
    {
        private readonly ICustomerOrderDataBase _db;

        private IProductService _productService;

        public LineService(IProductService productService, ICustomerOrderDataBase db)
        {
            _productService = productService;
            _db = db;
        }


        public IEnumerable<Product> GetCustomerOrder()
        {
            return _db.GetAll();
        }

        public bool AddLineItem(int productId)
        {
            var product = _productService.GetProduct(productId);
            if (product == null)
            {
                return false;
            }
            var orderLine = new ItemLine { Id = product.Id, Name = product.Name, Price = product.Price };
            var currentLines = _db.GetAll().Count();
            _db.Write(currentLines + 1 , orderLine);
            return true;
        }

        public void CloseTransaction()
        {
            var allItems = _db.GetAll();
            for (int i = 0; i < allItems.Count(); i++)
            {
                _db.Remove(i);
            }            
        }
    }
}
