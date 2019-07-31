using System.Collections.Generic;
using RoadRunnerServer.Shared;

namespace RoadRunnerServer.Shared
{
    public interface IProductService
    {
        Product GetProduct(int id);
        IList<Product> GetAllProducts();
    }
}
