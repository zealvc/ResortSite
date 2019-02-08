using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Resort.Application.Facebooks.Models;

namespace Resort.Persistence
{
    public class FacebookContext : DbContext
    {
        public FacebookContext(DbContextOptions<FacebookContext> options)
            : base(options)
        {
        }

        public DbSet<FacebookModel> FacebookModels { get; set; }
    }
}
