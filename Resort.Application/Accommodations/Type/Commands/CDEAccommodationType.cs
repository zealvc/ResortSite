using Resort.Domain.Entities;
using System.Collections.Generic;
using Resort.Application.Accommodations.Type.Models;

namespace Resort.Application.Accommodations.Type.Commands
{
    public class CDEAccommodationType
    {
        public string Create(AccommodationTypeModel typeModel)
        {
            try
            {
                ResortSiteDbContext context = new ResortSiteDbContext();
                Resort.Domain.Entities.AccommodationType am = new Resort.Domain.Entities.AccommodationType()
                {
                    Type = typeModel.Name
                    ,
                    LanguageId = typeModel.LanguageId
                };
                context.AccommodationType.Add(am);
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
                Resort.Domain.Entities.AccommodationType type = new Resort.Domain.Entities.AccommodationType() { Id = id };
                context.AccommodationType.Attach(type);
                context.AccommodationType.Remove(type);
                context.SaveChanges();
            }
            catch
            {

            }
            return "ok";
        }
    }
}
