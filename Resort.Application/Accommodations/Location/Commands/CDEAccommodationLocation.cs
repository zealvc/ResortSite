using System;
using System.Collections.Generic;
using System.Text;
using Resort.Application.Accommodations.Location.Models;
using Resort.Domain.Entities;

namespace Resort.Application.Accommodations.Location.Commands
{
    public class CDEAccommodationLocation
    {
        public string Create(AccoLocationModel locationModel)
        {
            try
            {
                ResortSiteDbContext context = new ResortSiteDbContext();
                Resort.Domain.Entities.AccommodationLocation am = new Resort.Domain.Entities.AccommodationLocation()
                {
                    Name = locationModel.Name
                    ,
                    Address = locationModel.Address
                    ,
                    Description = locationModel.Description
                    ,
                    Distance = locationModel.Distance
                    ,
                    DistanceDescription = locationModel.DistanceDescription
                    ,
                    Longitude = locationModel.Longitude
                    ,
                    Latitude = locationModel.Latitude
                    ,
                    LanguageId = locationModel.LanguageId
                };
                context.AccommodationLocation.Add(am);
                context.SaveChanges();
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
                Resort.Domain.Entities.AccommodationLocation type = new Resort.Domain.Entities.AccommodationLocation() { Id = id };
                context.AccommodationLocation.Attach(type);
                context.AccommodationLocation.Remove(type);
                context.SaveChanges();
            }
            catch
            {

            }
            return "ok";
        }
    }
}
