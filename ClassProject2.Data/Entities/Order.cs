using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassProject2.Data.Entities
{
    /// <summary>Represents an order.</summary>
    [Table("Orders")]
    public class Order : IEntityBase
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("CustomerId"), ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Column("OrderDate")]
        public DateTime OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
