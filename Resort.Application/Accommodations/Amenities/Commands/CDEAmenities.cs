using Resort.Application.Accommodations.Amenities.Models;
using Resort.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Resort.Application.Accommodations.Amenities.Commands
{
    public class CDEAmenities
    {
        public string Create(AmenityModel amenityModel)
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            Resort.Domain.Entities.Amenity am = new Resort.Domain.Entities.Amenity()
            {
                Name = amenityModel.Name
                ,
                Description = amenityModel.Description
                ,
                LanguageId = amenityModel.LanguageId
            };
            context.Amenity.Add(am);
            context.SaveChanges();
            return "ok";
        }
        public string Delete(int id)
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            Resort.Domain.Entities.Amenity amenity = new Resort.Domain.Entities.Amenity() { Id = id };
            context.Amenity.Attach(amenity);
            context.Amenity.Remove(amenity);
            context.SaveChanges();
            return "ok";
        }
    }
}
