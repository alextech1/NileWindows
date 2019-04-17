using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsData
{
    public class Customers
    {
        public Customers()
        {
            _customers = new List<Customer>()
            {
                new Customer(_ids.Next())
                {
                    FirstName = "Bob", LastName = "Miller"
                },
                new Customer(_ids.Next())
                {
                    FirstName = "Sue",
                    LastName = "Storm"
                },
                new Customer(_ids.Next())
                {
                    FirstName = "Peter",
                    LastName = "Parker"
                }
            };
        }

        /// <summary>Adds a customer to the list.</summary>
        /// <param name="customer">The customer.</param>
        /// <exception cref="ArgumentNullException"><paramref name="customer"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="customer"/> should not already exist.</exception>
        /// <exception cref="ValidationException"><paramref name="customer"/> is not valid.</exception>        
        /// <returns>The new product.</returns>
        public Customer Add(Customer customer)
        {
            //Cannot be null
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            //Should be valid 
            Validator.ValidateObject(customer, new ValidationContext(customer));

            //Should not already exist            
            if (_customers.Any(c => String.Compare(c.FirstName, customer.FirstName, true) == 0 &&
                                    String.Compare(c.LastName, customer.LastName, true) == 0))
                throw new ArgumentException("Customer already exists.", nameof(customer));

            //Set the ID
            customer.Id = _ids.Next();

            //Add to the list
            _customers.Add(customer);

            return customer;
        }

        public Customer Get(int id)
        {
            //var items = _customers.Where(c =>
            //{
            //    return id == c.Id;
            //})

            return (from c in _customers
                    where id == c.Id
                    select c
                   ).FirstOrDefault();
            //return _customers
            //         .Where(c => id == c.Id)
            //         .FirstOrDefault();

            //foreach (var customer in _customers)
            //{
            //    if (id == customer.Id)
            //        return customer;
            //};

            //return null;
        }

        /// <summary>Gets all the customers.</summary>
        /// <returns>The list of customers.</returns>
        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        /// <summary>Removes a customer.</summary>
        /// <param name="id">The ID.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than 1.</exception>
        public void Remove(int id)
        {
            //Verify > 0
            if (id <= 0)
                throw new ArgumentOutOfRangeException("Id must be > 0", nameof(id));

            //Find the item
            var item = _customers.FirstOrDefault(i => i.Id == id);

            //Remove it
            if (item != null)
                _customers.Remove(item);
        }

        private readonly List<Customer> _customers;
        private readonly Sequence _ids = new Sequence(100);
    }
}
