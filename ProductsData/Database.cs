using ProductsData.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsData
{
    public class Database : IDisposable
    {
        public Database(string connectionString)
        {
            _context = new ProductsDbContext(connectionString);
        }

        public Customers Customers { get; private set; } = new Customers();

        public Products Products
        {
            get { return new Products(_context); }
        }

        private readonly ProductsDbContext _context;

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
