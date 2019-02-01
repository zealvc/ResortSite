using System;
using System.Collections.Generic;

namespace Resort.Domain.Entities
{
    public partial class Feature
    {
        public long Id { get; set; }
        public long AccommodationId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string CoverImage { get; set; }
        public string Description { get; set; }

        public virtual Accommodation Accommodation { get; set; }
    }
}
