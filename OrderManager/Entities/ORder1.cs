using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Entities
{
    public  class ORder1
    {
        public int Id { get; set; }

        public string? OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }


        public Product Product { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
