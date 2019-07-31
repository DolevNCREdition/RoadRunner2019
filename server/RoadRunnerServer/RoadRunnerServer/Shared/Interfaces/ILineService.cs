﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoadRunnerServer.Shared
{
    public interface ILineService
    {
        IEnumerable<Product> GetCustomerOrder();

        //bool AppendLine(int productId);
        Task<bool> AppendLineAsync(LineTypeEnum lineType, int productId);

        void CloseTransaction();
    }
}
