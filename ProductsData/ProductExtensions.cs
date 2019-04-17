using ProductsData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsData
{
    /// <summary>Provides extension methods for products.</summary>
    public static class ProductExtensions
    {
        /// <summary>Gets the list of available products.</summary>
        /// <param name="source">The source.</param>
        /// <returns>The list of available products.</returns>
        public static IEnumerable<Product> GetAvailable(this Products source)
        {
            //source.GetAll().OrderBy(i => i.Name).Th
            return from p in source.GetAll()
                   where !p.IsDiscontinued
                   orderby p.Name descending, p.UnitPrice
                   select p;
        }
    }
}
