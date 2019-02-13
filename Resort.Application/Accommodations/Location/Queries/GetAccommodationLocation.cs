using Resort.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resort.Application.Accommodations.Location.Queries
{
    public class GetAccommodationLocation
    {
        public Resort.Domain.Entities.AccommodationLocation GetOne(int id)
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            Resort.Domain.Entities.AccommodationLocation location = context.AccommodationLocation.Single(i => i.Id == id);
            return location;
        }

        public List<Resort.Domain.Entities.AccommodationLocation> GetAll()
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            List<Resort.Domain.Entities.AccommodationLocation> location = context.AccommodationLocation.ToList();
            return location;
        }
    }
}
