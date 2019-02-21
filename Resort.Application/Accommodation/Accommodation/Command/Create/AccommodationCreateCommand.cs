using Resort.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resort.Application
{
    public class AccommodationCreateCommand
    {
        private readonly ResortSiteDbContext _context;

        public string Name { get; set; }
        public long AccommodationTypeId { get; set; }
        public string Description { get; set; }
        public int? GuestCount { get; set; }
        public int? BedRoomCount { get; set; }
        public int? BedCount { get; set; }
        public int? BathCount { get; set; }
        public long? LocationId { get; set; }
        public decimal? PricePerNight { get; set; }
        public string CoverImage { get; set; }
        public string MainImage { get; set; }
        public string CancellationPolicy { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? LanguageId { get; set; }

        public AccommodationCreateCommand(ResortSiteDbContext context)
        {
            _context = context;
        }

        public void Create(AccommodationCreateCommand request)
        {
            var accommodation = new Accommodation
            {
                Name = request.Name,
                AccommodationTypeId = request.AccommodationTypeId,
                Description = request.Description,
                GuestCount = request.GuestCount,
                BedRoomCount = request.BedRoomCount,
                BedCount = request.BedCount,
                BathCount = request.BathCount,
                LocationId = request.LocationId,
                PricePerNight = request.PricePerNight,
                CoverImage = request.CoverImage,
                MainImage = request.MainImage,
                CancellationPolicy = request.CancellationPolicy,
                DateAdded = request.DateAdded,
                LanguageId = request.LanguageId
            };
            _context.Add(accommodation);
            _context.SaveChanges();
        }
    }
}
