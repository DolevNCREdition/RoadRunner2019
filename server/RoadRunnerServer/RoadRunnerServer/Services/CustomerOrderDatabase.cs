using Microsoft.Extensions.Caching.Memory;
using RoadRunnerServer.Shared;

namespace RoadRunnerServer.Services
{
    public class CustomerOrderDatabase : DataBase<ItemLine>, ICustomerOrderDataBase
    {
        public CustomerOrderDatabase(IMemoryCache cache) : base(cache)
        {
        }
    }
}
