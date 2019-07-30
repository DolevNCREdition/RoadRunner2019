
using RoadRunnerServer.Shared.Models;

namespace RoadRunnerServer.Services.Interfaces
{
    public interface IProductService
    {
        Product GetProduct(int id);
    }
}
