using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Poland",
                    ShortName = "Pl"
                },
                new Country()
                {
                    Id = 2,
                    Name = "Germany",
                    ShortName = "Ger"
                },
                new Country()
                {
                    Id = 3,
                    Name = "England",
                    ShortName = "En"
                }
                );
            builder.Entity<Club>().HasData(
               new Club
               {
                   Id = 1,
                   Name = "FC Barcelona",
                   Ligue = "LaLiga",
                   CountryId = 1,
                   Rating = 6.6
               },
               new Club()
               {
                   Id = 2,
                   Name = "Manchester United",
                   Ligue = "Premier League",
                   CountryId = 2,
                   Rating = 5.5
               },
               new Club()
               {
                   Id = 3,
                   Name = "Bayern Monachium",
                   Ligue = "Bundesliga",
                   CountryId = 2,
                   Rating = 8.7
               }
               );
        }
    }
}
