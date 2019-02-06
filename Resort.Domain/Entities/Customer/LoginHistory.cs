using System;
using System.Collections.Generic;

namespace Resort.Domain.Entities
{
    public partial class LoginHistory
    {
        public long CustomerId { get; set; }
        public string Browser { get; set; }
        public string Device { get; set; }
        public string Ip { get; set; }
        public DateTime? Date { get; set; }
        public string RecentActivity { get; set; }
        public int? NumberOfLoginPerDay { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
