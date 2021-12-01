using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Configurations.Entities;

namespace WebApplication1.Data
{
    public class DatabaseContext: IdentityDbContext<ApiUser>
    {
       public DatabaseContext(DbContextOptions options): base(options)
        {}
        
        public DbSet<Country> Countries { get; set; }
        public DbSet<Club> Clubs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new ClubConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
