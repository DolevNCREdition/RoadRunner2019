
using RoadRunnerServer.Models;

namespace RoadRunnerServer.Shared
{
    public class Product : IDbObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
    }
}
