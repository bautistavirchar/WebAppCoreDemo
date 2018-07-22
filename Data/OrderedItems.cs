using System;
using System.Collections.Generic;

namespace WebAppCoreDemo.Data
{
    public partial class OrderedItems
    {
        public int Id { get; set; }
        public int Customer { get; set; }
        public int Product { get; set; }
        public int Status { get; set; }
        public DateTime TimeStamp { get; set; }

        public Customers CustomerNavigation { get; set; }
        public Products ProductNavigation { get; set; }
        public OrderedStatus StatusNavigation { get; set; }
    }
}
