using RoadRunnerServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadRunnerServer.Services
{
    public class ProductService : IProductService
    {
        private List<Product> _products = new List<Product> {
            new Product { Id = 1, Name = "Hamburger Patty", Price = new Price{ Symbol='$', Value= 3.59 } },
            new Product { Id = 2, Name = "Lettuce", Price = new Price{ Symbol='$', Value= 1.25 } },
            new Product { Id = 3, Name = "Tomato", Price = new Price{ Symbol='$', Value= 2.50 } },
            new Product { Id = 4, Name = "Carrot", Price = new Price{ Symbol='$', Value= 2.24 } },
            new Product { Id = 5, Name = "Ketchup", Price = new Price{ Symbol='$', Value= 4.20 } },
            new Product { Id = 6, Name = "Hamburger Bun", Price = new Price{ Symbol='$', Value= 1.50 } },
            new Product { Id = 7, Name = "Hot Dog", Price = new Price{ Symbol='$', Value= 2.89 } },
            new Product { Id = 8, Name = "Thousand isles sauce", Price = new Price{ Symbol='$', Value= 4.76 } },
            new Product { Id = 9, Name = "Fresh fish", Price = new Price{ Symbol='$', Value= 10.32 } },
            new Product { Id = 10, Name = "Feta Cheese", Price = new Price{ Symbol='$', Value= 3.27 } },
            new Product { Id = 11, Name = "Watermelon", Price = new Price{ Symbol='$', Value= 3.12 } },
            new Product { Id = 12, Name = "Snickers Bar", Price = new Price{ Symbol='$', Value= 0.90 } },
            new Product { Id = 13, Name = "Espresso", Price = new Price{ Symbol='$', Value= 1.25 } },
            new Product { Id = 14, Name = "Cucumber", Price = new Price{ Symbol='$', Value= 1.50 } },
            new Product { Id = 15, Name = "Pickles", Price = new Price{ Symbol='$', Value= 2.00 } },
            new Product { Id = 16, Name = "Pasta", Price = new Price{ Symbol='$', Value= 3.17 } }
        };

        public Product GetProduct(int id)
        {
            return _products.Find(product => product.Id == id);
        }
    }
}
