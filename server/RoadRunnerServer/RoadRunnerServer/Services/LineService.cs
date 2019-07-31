using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using RoadRunnerServer.Shared;

namespace RoadRunnerServer.Services
{
    public class LineService : ILineService
    {
        private readonly ICustomerOrderDataBase _db;
        private readonly ISellingPipeline _sellingPipeline;
        private readonly IProductService _productService;

        public LineService(IProductService productService, ICustomerOrderDataBase db, ISellingPipeline sellingPipeline)
        {
            _productService = productService;
            _sellingPipeline = sellingPipeline;
            _db = db;
        }


        public IEnumerable<Product> GetCustomerOrder()
        {
            return _db.GetAll();
        }

        public async Task<bool> AppendLineAsync(int productId)
        {
            var product = _productService.GetProduct(productId);
            if (product == null)
            {
                return await Task.FromResult(false) ;
            }

            var orderLine = new ItemLine { Id = product.Id, Name = product.Name, Price = product.Price };
            return  await _sellingPipeline.ProcessLine.SendAsync(orderLine);
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
