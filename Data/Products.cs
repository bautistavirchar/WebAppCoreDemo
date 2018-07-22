using System;
using System.Collections.Generic;

namespace WebAppCoreDemo.Data
{
    public partial class Products
    {
        public Products()
        {
            OrderedItems = new HashSet<OrderedItems>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }

        public Status StatusNavigation { get; set; }
        public ICollection<OrderedItems> OrderedItems { get; set; }
    }
}
