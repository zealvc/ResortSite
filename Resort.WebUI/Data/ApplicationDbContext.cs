 
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resort.WebUI.Models.Entities;

namespace Resort.WebUI.Data
{
  public class ApplicationDbContext : IdentityDbContext<AppUser>
  {
    public ApplicationDbContext(DbContextOptions options)
      : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
  }
}
