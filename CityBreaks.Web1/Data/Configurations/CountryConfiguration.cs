using CityBreaks.Web1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web1.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id_country");
            builder.Property(e => e.CountryName).HasMaxLength(50);
            builder.HasData(new List<Country> {
                new Country { Id = 1, CountryCode = "BR", CountryName = "Brasil"},
                new Country { Id = 2, CountryCode = "AR", CountryName = "Argentina"},
                new Country { Id = 3, CountryCode = "FR", CountryName = "França"}
            });

        }
    }
}
