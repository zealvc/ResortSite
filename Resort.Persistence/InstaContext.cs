using Microsoft.EntityFrameworkCore;
using Resort.Application.Instagrams.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resort.Persistence
{
    public class InstaContext : DbContext
    {

        public InstaContext(DbContextOptions<InstaContext> options)
           : base(options)
        {
        }

        public DbSet<InstaModel> InstaModels { get; set; }
    }
}
