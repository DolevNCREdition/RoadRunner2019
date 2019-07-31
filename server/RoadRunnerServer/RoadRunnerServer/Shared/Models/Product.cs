﻿
using RoadRunnerServer.Models;

namespace RoadRunnerServer.Shared.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
    }
}