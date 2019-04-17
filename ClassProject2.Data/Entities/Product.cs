using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassProject2.Data.Entities
{
    [Table("Products")]
    public class Product : IEntityBase
    {
        [Column("Id")]        
        public int Id { get; set; }
        
        [Column("Name")] 
        [Required(AllowEmptyStrings = true)]
        [StringLength(100)]
        public string Name { get; set; }

        [Column("Discontinued")]
        public bool IsDiscontinued { get; set; }

        [Column("UnitPrice")]
        [Range(0.01, (double)Decimal.MaxValue, ErrorMessage = "Price must be > 0")]
        public decimal UnitPrice { get; set; }
    }
}
