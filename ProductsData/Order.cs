using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsData
{
    /// <summary>Represents an order.</summary>
    public class Order
    {
        public Order()
        { }

        public Order(int id)
        {
            //TODO: Should verify ID is > 0
            if (id > 0)
                Id = id;
        }

        public int Id { get; private set; }

        public Collection<LineItem> LineItems
        { get; } = new Collection<LineItem>();
    }
}
