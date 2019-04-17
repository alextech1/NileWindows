using ProductsData;
using ClassProject2.Mvc.Models;
using ProductsData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassProject2.Mvc.Extensions
{
    public static class ProductExtensions
    {
        public static IEnumerable<ProductModel> ToModel(
                            this IEnumerable<Product> source)
        {
            return from p in source
                   select new ProductModel(p);
        }

        public static Product ToBusiness(this ProductModel source)
        {
            return new Product()
            {
                Id = source.Id,
                Name = source.Name,
                UnitPrice = source.Price,
                IsDiscontinued = source.IsDiscontinued
            };
        }
    }
}