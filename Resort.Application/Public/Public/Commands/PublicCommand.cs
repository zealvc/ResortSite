using System;
using System.Collections.Generic;
using System.Text;
using Resort.Application.Accommodation.Models;
using Resort.Application.Accommodation.Queries;
using Microsoft.EntityFrameworkCore;
using Resort.Domain.Entities;
using Resort.Persistence.Repository_and_Unit_of_Work_Implimentation;

namespace Resort.Application.Accommodation.Commands
{
    public class PublicCommand : Repository<PublicModel>, IPublicQuery
    {
        public PublicCommand(ResortSiteDbContext context) : base(context)
        {

        }

        //Save Database Transaction

        public void Complete()
        {
            Context.SaveChanges();
        }

        public ResortSiteDbContext ResortSiteDbContext
        {
            get { return Context as ResortSiteDbContext; }
        }
    }
}
