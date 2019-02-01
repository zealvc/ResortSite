using System;
using System.Collections.Generic;

namespace Resort.Domain.Entities
{
    public partial class AccommodationImage
    {
        public long AccommodationId { get; set; }
        public string Images { get; set; }

        public virtual Accommodation Accommodation { get; set; }
    }
}
