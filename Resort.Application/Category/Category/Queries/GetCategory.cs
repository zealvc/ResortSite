using Resort.Application.Accommodation.Models;
using Resort.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Resort.Application.Category.Category.Queries
{
    public class GetCategory
    {
        public Resort.Domain.Entities.Category GetOne(int id)
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            Resort.Domain.Entities.Category category = context.Category.Single(i => i.Id == id);
            Debug.WriteLine("Test: " + category.Description);
            return category;
        }

        public List<Resort.Domain.Entities.Category> GetAll()
        {
            ResortSiteDbContext context = new ResortSiteDbContext();
            List<Resort.Domain.Entities.Category> category = context.Category.ToList();
            return category;
        }
    }
}
