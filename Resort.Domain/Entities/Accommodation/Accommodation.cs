using System;
using System.Collections.Generic;

namespace Resort.Domain.Entities
{
    public partial class Accommodation
    {
        public Accommodation()
        {
            Reservation = new HashSet<Reservation>();
        }

        public long Id { get; set; }
        public long? CategoryId { get; set; }
        public string Name { get; set; }
        public long AccommodationTypeId { get; set; }
        public string Description { get; set; }
        public int? GuestCount { get; set; }
        public int? BedRoomCount { get; set; }
        public int? BedCount { get; set; }
        public int? BathCount { get; set; }
        public long? LocationId { get; set; }
        public string AccessibilitySizeDescription { get; set; }
        public decimal PricePerNight { get; set; }
        public string CancellationPolicy { get; set; }
        public DateTime? DateAdded { get; set; }

        public virtual AccommodationType AccommodationType { get; set; }
        public virtual Category Category { get; set; }
        public virtual AccommodationImage IdNavigation { get; set; }
        public virtual Location Location { get; set; }
        public virtual Accessibility Accessibility { get; set; }
        public virtual AccommodationAmenity AccommodationAmenity { get; set; }
        public virtual AccommodationHouseRule AccommodationHouseRule { get; set; }
        public virtual Feature Feature { get; set; }
        public virtual Rating Rating { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
