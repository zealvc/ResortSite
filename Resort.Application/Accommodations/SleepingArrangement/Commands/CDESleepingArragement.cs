using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Resort.Application.Accommodations.SleepingArrangement.Models;
using Resort.Domain.Entities;

namespace Resort.Application.Accommodations.SleepingArrangement.Commands
{
    public class CDESleepingArragement
    {
        public Resort.Domain.Entities.SleepingArrangement GetOne(int id)
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            Resort.Domain.Entities.SleepingArrangement house = context.SleepingArrangement.Single(i => i.AccommodationId == id);
            return house;
        }

        public List<Resort.Domain.Entities.SleepingArrangement> GetAll()
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            List<Resort.Domain.Entities.SleepingArrangement> houses = context.SleepingArrangement.ToList();
            return houses;
        }
        public string Create(SleppingArragement_Model locationModel)
        {
            try
            {
                ResortSiteDbContext context = new ResortSiteDbContext();
                Resort.Domain.Entities.SleepingArrangement am = new Resort.Domain.Entities.SleepingArrangement()
                {
                    Name = locationModel.Name
                    ,
                    LanguageId = locationModel.LanguageId
                };
                context.SleepingArrangement.Add(am);
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
                Resort.Domain.Entities.SleepingArrangement sleeping = new Resort.Domain.Entities.SleepingArrangement() { AccommodationId = id };
                context.SleepingArrangement.Attach(sleeping);
                context.SleepingArrangement.Remove(sleeping);
                context.SaveChanges();
            }
            catch
            {

            }
            return "ok";
        }
    }
}
