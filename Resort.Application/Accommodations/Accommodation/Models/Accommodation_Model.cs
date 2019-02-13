using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resort.Application.Accommodations.Accommodation.Models
{
    public class Accommodation_Model
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public long AccommodationTypeId { get; set; }
        public string Description { get; set; }
        public int? GuestCount { get; set; }
        public int? BedRoomCount { get; set; }
        public int? BedCount { get; set; }
        public int? BathCount { get; set; }
        public long LocationId { get; set; }
        public decimal? PricePerNight { get; set; }
        public IFormFile CoverImage { get; set; }
        public IFormFile MainImage { get; set; }
        public string CancellationPolicy { get; set; }
        public long? LanguageId { get; set; }
    }
}
