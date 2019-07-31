using RoadRunnerServer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadRunnerServer.Services
{
    public interface ILineService
    {
        IEnumerable<Product> GetCustomerOrder();

        bool AddLineItem(int productId);

        void CloseTransaction();
    }
}
