using System;
using System.Collections.Generic;

namespace Resort.Domain.Entities
{
    public partial class PhoneNumber
    {
        public long CustomerId { get; set; }
        public string Phone { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
