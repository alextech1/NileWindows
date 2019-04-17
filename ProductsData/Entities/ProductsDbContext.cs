using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsData.Entities
{
    internal class ProductsDbContext : DbContext
    {
        static ProductsDbContext()
        {
            System.Data.Entity.Database.SetInitializer<ProductsDbContext>(null);
        }

        public ProductsDbContext(string name) : base(name)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
