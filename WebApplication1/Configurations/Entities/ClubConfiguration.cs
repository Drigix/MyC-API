using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data;

namespace WebApplication1.Configurations.Entities
{
    public class ClubConfiguration: IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.HasData(
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
