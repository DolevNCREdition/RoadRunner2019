using RoadRunnerServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadRunnerServer.Services
{
    public interface IProductService
    {
        Product GetProduct(int id);
    }
}
