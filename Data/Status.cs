using System;
using System.Collections.Generic;

namespace WebAppCoreDemo.Data
{
    public partial class Status
    {
        public Status()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
