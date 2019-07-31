using RoadRunnerServer.Shared.Models;

using RoadRunnerServer.Services.Interfaces;
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
    }
}
