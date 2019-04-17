
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassProject2.Data.Entities
{
    /// <summary>Represents a customer.</summary>
    [Table("Customers")]
    public class Customer: IEntityBase
    {
        /// <summary>Gets the unique ID of the customer.</summary>
        [Column("Id")]        
        public int Id { get; set; }

        [Column("FirstName")]
        /// <summary>Gets or sets the first name.</summary>
        public string FirstName { get; set; }

        [Column("LastName")]
        /// <summary>Gets or sets the last name.</summary>
        public string LastName { get; set; }        
    }
}
