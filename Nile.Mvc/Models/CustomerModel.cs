using ClassProject2.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nile.Mvc.Models
{
    public class CustomerModel : IValidatableObject
    {
        public CustomerModel()
        {
        }

        public CustomerModel(Customer data)
        {
            Id = data.Id;
            FirstName = data.FirstName;
            LastName = data.LastName;
        }

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(FirstName))
                yield return new ValidationResult("First Name is required", new[] { "FirstName" });

            if (string.IsNullOrEmpty(LastName))
                yield return new ValidationResult("Last Name is required", new[] { "LastName" });            
        }
    }
}