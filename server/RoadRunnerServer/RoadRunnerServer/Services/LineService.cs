using System.Collections.Generic;
using System.Linq;
using RoadRunnerServer.Shared;

namespace RoadRunnerServer.Services
{
    public class LineService : ILineService
    {
        private readonly ICustomerOrderDataBase _db;

        private readonly IProductService _productService;

        public LineService(IProductService productService, ICustomerOrderDataBase db)
        {
            _productService = productService;
            _db = db;
        }


        public IEnumerable<Product> GetCustomerOrder()
        {
            return _db.GetAll();
        }

        public bool AppendLine(int productId)
        {
            var product = _productService.GetProduct(productId);
            if (product == null)
            {
                return false;
            }
            var orderLine = new ItemLine { Id = product.Id, Name = product.Name, Price = product.Price };
            return true;
        }

        public void CloseTransaction()
        {
            var allItems = _db.GetAll().ToList();
            for (int i = 0; i < allItems.Count; i++)
            {
                _db.Remove(i);
            }            
        }
    }
}
