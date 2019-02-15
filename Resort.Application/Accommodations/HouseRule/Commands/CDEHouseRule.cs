using Resort.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Resort.Application.Accommodations.HouseRule.Models;

namespace Resort.Application.Accommodations.HouseRule.Commands
{
    public class CDEHouseRule
    {
        public Resort.Domain.Entities.HouseRule GetOne(int id)
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            Resort.Domain.Entities.HouseRule house = context.HouseRule.Single(i => i.Id == id);
            return house;
        }

        public List<Resort.Domain.Entities.HouseRule> GetAll()
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            List<Resort.Domain.Entities.HouseRule> houses = context.HouseRule.ToList();
            return houses;
        }
        public string Create(HouseRule_Model locationModel)
        {
            try
            {
                ResortSiteDbContext context = new ResortSiteDbContext();
                Resort.Domain.Entities.HouseRule am = new Resort.Domain.Entities.HouseRule()
                {
                    Name = locationModel.Name
                    ,
                    LanguageId = locationModel.LanguageId
                };
                context.HouseRule.Add(am);
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
                Resort.Domain.Entities.HouseRule house = new Resort.Domain.Entities.HouseRule() { Id = id };
                context.HouseRule.Attach(house);
                context.HouseRule.Remove(house);
                context.SaveChanges();
            }
            catch
            {

            }
            return "ok";
        }
    }
}
