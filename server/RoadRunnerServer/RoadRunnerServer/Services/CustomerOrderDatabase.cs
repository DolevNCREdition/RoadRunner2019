using RoadRunnerServer.Shared.Interfaces;
using RoadRunnerServer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadRunnerServer.Services
{
    public class CustomerOrderDatabase : DataBase<ItemLine>, ICustomerOrderDataBase
    {
    }
}
