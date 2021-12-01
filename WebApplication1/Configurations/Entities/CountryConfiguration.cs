using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data;

namespace WebApplication1.Configurations.Entities
{
    public class CountryConfiguration: IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
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
        }
    }
}
