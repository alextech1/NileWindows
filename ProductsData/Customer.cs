using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsData
{
    /// <summary>Represents a customer.</summary>
    public class Customer : IValidatableObject
    {
        public Customer()
        { }

        public Customer(int id)
        {
            //TODO: Should verify it is > 0
            if (id > 0)
                Id = id;
        }

        /// <summary>Gets the unique ID of the customer.</summary>
        public int Id { get; internal set; }

        /// <summary>Gets or sets the current order.</summary>
        public Order CurrentOrder { get; } = new Order();

        /// <summary>Gets or sets the first name.</summary>
        public string FirstName
        {
            get { return _firstName ?? ""; }
            set
            {
                //_firstName = StringExtensions.ToPascalCase(value);
                _firstName = value.ToPascalCase();
            }
        }

        /// <summary>Gets or sets the last name.</summary>
        public string LastName
        {
            get { return _lastName ?? ""; }
            set { _lastName = value.ToPascalCase(); }
        }

        private string _firstName, _lastName;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(FirstName))
                yield return new ValidationResult("First Name is required",
                                               new[] { "FirstName" });

            if (String.IsNullOrEmpty(LastName))
                yield return new ValidationResult("Last Name is required",
                                               new[] { "LastName" });
        }
    }
}
