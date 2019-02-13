using Resort.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resort.Application.Accommodations.Amenities.Queries
{
    public class GetAmenity
    {
        public Resort.Domain.Entities.Amenity GetOne(int id)
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            Resort.Domain.Entities.Amenity amenity = context.Amenity.Single(i => i.Id == id);
            return amenity;
        }

        public List<Resort.Domain.Entities.Amenity> GetAll()
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            List<Resort.Domain.Entities.Amenity> amenities = context.Amenity.ToList();
            return amenities;
        }
    }
}
