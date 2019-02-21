using Resort.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Resort.Application
{
    public class AccommodationModel
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public long AccommodationTypeId { get; set; }
        public string Description { get; set; }
        public int? GuestCount { get; set; }
        public int? BedRoomCount { get; set; }
        public int? BedCount { get; set; }
        public int? BathCount { get; set; }

        public static Expression<Func<Accommodation ,AccommodationModel>> Projection
        {
            get
            {
                return x => new AccommodationModel
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    AccommodationTypeId = x.AccommodationTypeId,
                    Description = x.Description,
                    GuestCount = x.GuestCount,
                    BedRoomCount = x.BedRoomCount,
                    BedCount = x.BedCount,
                    BathCount = x.BathCount
                };
            }
        }
    }
}
