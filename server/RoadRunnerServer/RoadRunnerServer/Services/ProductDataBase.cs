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
            int i = 0;
            Write(++i, new Product { Id = i, Name = "Hamburger Patty", Price = new Price { Symbol = '$', Value = 3.59 } });
            Write(++i, new Product { Id = i, Name = "Lettuce", Price = new Price { Symbol = '$', Value = 1.25 } });
            Write(++i, new Product { Id = i, Name = "Carrot", Price = new Price { Symbol = '$', Value = 2.24 } });
            Write(++i, new Product { Id = i, Name = "Ketchup", Price = new Price { Symbol = '$', Value = 4.20 } });
            Write(++i, new Product { Id = i, Name = "Hamburger Bun", Price = new Price { Symbol = '$', Value = 1.50 } });
            Write(++i, new Product { Id = i, Name = "Hot Dog", Price = new Price { Symbol = '$', Value = 2.89 } });
            Write(++i, new Product { Id = i, Name = "Thousand isles sauce", Price = new Price { Symbol = '$', Value = 4.76 } });
            Write(++i, new Product { Id = i, Name = "Fresh fish", Price = new Price { Symbol = '$', Value = 10.32 } });
            Write(++i, new Product { Id = i, Name = "Feta Cheese", Price = new Price { Symbol = '$', Value = 3.27 } });
            Write(++i, new Product { Id = i, Name = "Watermelon", Price = new Price { Symbol = '$', Value = 3.12 } });
            Write(++i, new Product { Id = i, Name = "Snickers Bar", Price = new Price { Symbol = '$', Value = 0.90 } });
            Write(++i, new Product { Id = i, Name = "Espresso", Price = new Price { Symbol = '$', Value = 1.25 } });
            Write(++i, new Product { Id = i, Name = "Cucumber", Price = new Price { Symbol = '$', Value = 1.50 } });
            Write(++i, new Product { Id = i, Name = "Pickles", Price = new Price { Symbol = '$', Value = 2.00 } });
            Write(++i, new Product { Id = i, Name = "Pasta", Price = new Price { Symbol = '$', Value = 3.17 } });
        }
    }
}
