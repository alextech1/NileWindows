using ProductsData.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsData
{
    /// <summary>Represents a table of products.</summary>
    public class Products
    {
        internal Products(ProductsDbContext database)
        {
            _database = database;
        }

        private readonly ProductsDbContext _database;

        public void Add(Product product)
        {
            Validator.ValidateObject(product, new ValidationContext(product));

            var data = _database.Products.Create();
            data.Name = product.Name;
            data.IsDiscontinued = product.IsDiscontinued;
            data.UnitPrice = product.UnitPrice;

            data = _database.Products.Add(data);

            _database.SaveChanges();
        }

        /// <summary>Gets a specific product.</summary>
        /// <param name="id">The ID.</param>
        /// <returns>The product, if any.</returns>
        public Product Get(int id)
        {
            return _database.Products.FirstOrDefault(i => i.Id == id);
        }

        /// <summary>Gets all the products.</summary>
        /// <returns>The list of products.</returns>
        public IEnumerable<Product> GetAll()
        {
            var items = from p in _database.Products
                        where !p.IsDiscontinued
                        select p;

            return items.ToList();
        }

        public void Update(Product product)
        {
            Validator.ValidateObject(product, new ValidationContext(product));

            var existing = _database.Products
                            .FirstOrDefault(i => i.Id == product.Id);
            UpdateData(existing, product);

            _database.SaveChanges();
        }

        private void UpdateData(Product target, Product source)
        {
            target.Name = source.Name;
            target.IsDiscontinued = source.IsDiscontinued;
            target.UnitPrice = source.UnitPrice;
        }
    }
}
