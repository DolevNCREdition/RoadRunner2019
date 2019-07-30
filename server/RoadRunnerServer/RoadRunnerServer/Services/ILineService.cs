using RoadRunnerServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadRunnerServer.Services
{
    public interface ILineService
    {
        List<Product> LineItems { get; }

        bool AddLineItem(int productId);

        void CloseTransaction();
    }
}
