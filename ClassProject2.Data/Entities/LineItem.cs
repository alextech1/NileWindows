using System.ComponentModel.DataAnnotations.Schema;

namespace ClassProject2.Data.Entities
{
    /// <summary>Represents a line item.</summary>
    [Table("LineItems")]
    public class LineItem : IEntityBase
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("OrderId"), ForeignKey("Order")]
        public int OrderId { get; set; }

        [Column("ProductId"), ForeignKey("Product")]
        public int ProductId { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }   
        
        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
