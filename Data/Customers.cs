using System;
using System.Collections.Generic;

namespace WebAppCoreDemo.Data
{
    public partial class Customers
    {
        public Customers()
        {
            OrderedItems = new HashSet<OrderedItems>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<OrderedItems> OrderedItems { get; set; }
    }
}
