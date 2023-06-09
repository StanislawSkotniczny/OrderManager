﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public ICollection<ORder1> Order11ems { get; set; }
    }
}
