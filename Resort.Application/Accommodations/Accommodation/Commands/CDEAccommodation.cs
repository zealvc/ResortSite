using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Resort.Application.Accommodations.Accommodation.Models;
using Resort.Domain.Entities;

namespace Resort.Application.Accommodations.Accommodation.Commands
{
    public class CDEAccommodation
    {
        public Resort.Domain.Entities.Accommodation GetOne(int id)
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            Resort.Domain.Entities.Accommodation accommodation = context.Accommodation.Single(i => i.Id == id);
            return accommodation;
        }

        public List<Resort.Domain.Entities.Accommodation> GetAll()
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            List<Resort.Domain.Entities.Accommodation> accommodations = context.Accommodation.ToList();
            return accommodations;
        }
        public string Create(Accommodation_Model accommodation, int[] ListAmenityId, int[] ListHouseRuleId)
        {
            try
            {
                ResortSiteDbContext context = new ResortSiteDbContext();
                Resort.Domain.Entities.Accommodation am = new Resort.Domain.Entities.Accommodation()
                {
                    CategoryId = accommodation.CategoryId,
                    AccommodationTypeId = accommodation.AccommodationTypeId,
                    Name = accommodation.Name,
                    Description = accommodation.Description,
                    GuestCount = accommodation.GuestCount,
                    BedRoomCount =accommodation.BedRoomCount,
                    BedCount=accommodation.BedCount,
                    BathCount=accommodation.BathCount,
                    LocationId=accommodation.LocationId,
                    PricePerNight=accommodation.PricePerNight,
                    CancellationPolicy=accommodation.CancellationPolicy,
                    LanguageId = accommodation.LanguageId
                };
                context.Accommodation.Add(am);
                context.SaveChanges();
                Debug.WriteLine("Fighting for yourself!!!!");
                Debug.WriteLine(am.Id);
                Debug.WriteLine("Fighting for yourself!!!!");
                ResortSiteDbContext context1 = new ResortSiteDbContext();
                foreach (int Amenity in ListAmenityId)
                {
                    Resort.Domain.Entities.AccommodationAmenity amen = new Resort.Domain.Entities.AccommodationAmenity()
                    {
                        AccommodationId = am.Id,
                        AmenityId = Amenity
                    };
                    context1.AccommodationAmenity.Add(amen);
                }
                foreach (int rule in ListHouseRuleId)
                {
                    Resort.Domain.Entities.AccommodationHouseRule rul = new Resort.Domain.Entities.AccommodationHouseRule()
                    {
                        AccommodationId = am.Id,
                        HouseRuleId = rule
                    };
                    context1.AccommodationHouseRule.Add(rul);
                }
                context1.SaveChanges();
            }
            catch
            {

            }
            return "ok";
        }
        public string Delete(int id)
        {
            try
            {
                ResortSiteDbContext context = new ResortSiteDbContext();
                Resort.Domain.Entities.Accommodation accommodation = new Resort.Domain.Entities.Accommodation() { Id = id };
                context.Accommodation.Attach(accommodation);
                context.Accommodation.Remove(accommodation);
                context.SaveChanges();
            }
            catch
            {

            }
            return "ok";
        }
    }
}
