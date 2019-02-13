using Resort.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resort.Application.Accommodations.Type.Queries
{
    public class GetAccomodationType
    {
        public Resort.Domain.Entities.AccommodationType GetOne(int id)
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            Resort.Domain.Entities.AccommodationType type = context.AccommodationType.Single(i => i.Id == id);
            return type;
        }

        public List<Resort.Domain.Entities.AccommodationType> GetAll()
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            List<Resort.Domain.Entities.AccommodationType> types = context.AccommodationType.ToList();
            return types;
        }
    }
}
