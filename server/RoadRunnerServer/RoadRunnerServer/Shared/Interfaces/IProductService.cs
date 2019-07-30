using System.Collections.Generic;
using RoadRunnerServer.Shared.Models;

namespace RoadRunnerServer.Shared.Interfaces
{
    public interface IProductService
    {
        Product GetProduct(int id);
        IList<Product> GetAllProducts();
    }
}
