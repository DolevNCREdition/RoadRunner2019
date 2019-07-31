using Microsoft.Extensions.Caching.Memory;
using RoadRunnerServer.Models;
using RoadRunnerServer.Shared.Interfaces;
using Product = RoadRunnerServer.Shared.Models.Product;

namespace RoadRunnerServer.Services
{
    public class ProductDataBase : DataBase<Product>, IProductDataBase
    {
        public ProductDataBase(IMemoryCache cache) : base(cache)
        {
            Init();
        }

        private void Init()
        {
            Append(new Product { Name = "Hamburger Patty", Price = new Price { Symbol = '$', Value = 3.59 } });
            Append(new Product { Name = "Lettuce", Price = new Price { Symbol = '$', Value = 1.25 } });
            Append(new Product { Name = "Carrot", Price = new Price { Symbol = '$', Value = 2.24 } });
            Append(new Product { Name = "Ketchup", Price = new Price { Symbol = '$', Value = 4.20 } });
            Append(new Product { Name = "Hamburger Bun", Price = new Price { Symbol = '$', Value = 1.50 } });
            Append(new Product { Name = "Hot Dog", Price = new Price { Symbol = '$', Value = 2.89 } });
            Append(new Product { Name = "Thousand isles sauce", Price = new Price { Symbol = '$', Value = 4.76 } });
            Append(new Product { Name = "Fresh fish", Price = new Price { Symbol = '$', Value = 10.32 } });
            Append(new Product { Name = "Feta Cheese", Price = new Price { Symbol = '$', Value = 3.27 } });
            Append(new Product { Name = "Watermelon", Price = new Price { Symbol = '$', Value = 3.12 } });
            Append(new Product { Name = "Snickers Bar", Price = new Price { Symbol = '$', Value = 0.90 } });
            Append(new Product { Name = "Espresso", Price = new Price { Symbol = '$', Value = 1.25 } });
            Append(new Product { Name = "Cucumber", Price = new Price { Symbol = '$', Value = 1.50 } });
            Append(new Product { Name = "Pickles", Price = new Price { Symbol = '$', Value = 2.00 } });
            Append(new Product { Name = "Pasta", Price = new Price { Symbol = '$', Value = 3.17 } });
        }
    }
}
