using System;
using System.Collections.Generic;

namespace Resort.Domain.Entities
{
    public partial class Amenity
    {
        public Amenity()
        {
            AccommodationAmenity = new HashSet<AccommodationAmenity>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }

        public virtual ICollection<AccommodationAmenity> AccommodationAmenity { get; set; }
    }
}
