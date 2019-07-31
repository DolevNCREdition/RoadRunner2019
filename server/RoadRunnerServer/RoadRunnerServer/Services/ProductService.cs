using System.Collections.Generic;
using System.Linq;
using RoadRunnerServer.Shared.Models;
using RoadRunnerServer.Shared.Interfaces;

namespace RoadRunnerServer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDataBase _db;
        public ProductService( IProductDataBase db)
        {
            _db = db;
        }

        public Product GetProduct(int id)
        {
            return _db.Read(id);
        }

        public IList<Product> GetAllProducts()
        {
            return _db.GetAll().OrderBy( p=> p.Id).ToList();
        }
    }
}
