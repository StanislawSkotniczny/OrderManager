using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string SecondName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public ICollection<Order> Orders { get; set; }
        public ICollection<ORder1> Order1s { get; set; }

    }
}
