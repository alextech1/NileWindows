using ClassProject2.Data;
using ClassProject2.Data.Entities;
using Nile.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nile.Mvc.Extensions
{
    public static class CustomerExtension
    {
        public static IEnumerable<CustomerModel> ToModel (
                            this IEnumerable<Customer> source )
        {
            return from c in source
                   select new CustomerModel(c);
        }        
    }
}