using ProductsData;
using ProductsData.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassProject2.Mvc.Models
{
    public class ProductModel : IValidatableObject
    {
        public ProductModel()
        {
        }

        public ProductModel(Product data)
        {
            Id = data.Id;
            Name = data.Name;
            Price = data.UnitPrice;
            IsDiscontinued = data.IsDiscontinued;
        }

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Range(0.01, Double.MaxValue, ErrorMessage = "Price must be > 0.")]
        public decimal Price { get; set; }

        [Display(Name = "Is Discontinued")]
        public bool IsDiscontinued { get; set; }

        //public string Email { get; set; }

        //[Compare("Email")]
        //public string ConfirmEmail { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name == "Product")
                yield return new ValidationResult("Invalid product name",
                                                  new[] { "Name" });
        }
    }
}