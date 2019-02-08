using System;
using System.Collections.Generic;
using System.Text;
using Resort.Application.Implimentation;
using Resort.Application.Interface;
using Resort.Application.Accommodation.Models;
using Resort.Application.Accommodation.Queries;
using Microsoft.EntityFrameworkCore;

namespace Resort.Application.Accommodation.Commands
{
    class AccommodationCommand : Repository<AccommodationModel>, AccommodationQuery
    {
        public AccommodationCommand(DbContext context) : base(context)
        {
        }

        public void Complete()
        {
            Context.SaveChanges();
        }
    }
}
