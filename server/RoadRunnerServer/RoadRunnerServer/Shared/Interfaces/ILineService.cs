using System.Collections.Generic;

namespace RoadRunnerServer.Shared
{
    public interface ILineService
    {
        IEnumerable<Product> GetCustomerOrder();

        bool AppendLine(int productId);

        void CloseTransaction();
    }
}
