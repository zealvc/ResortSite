using System;
using System.Collections.Generic;

namespace Resort.Domain.Entities
{
    public partial class Type
    {
        public Type()
        {
            Customer = new HashSet<Customer>();
        }

        public long Id { get; set; }
        public string Type1 { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
