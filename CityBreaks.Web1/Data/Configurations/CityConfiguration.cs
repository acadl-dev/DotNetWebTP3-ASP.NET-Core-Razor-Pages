using CityBreaks.Web1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web1.Data.Configurations
{
    public class CityConfiguration:IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id_city");
            builder.HasData(new List<City> {
                new City { Id = 1, Name = "João Pessoa", CountryId = 1},
                new City { Id = 2, Name = "Fortaleza", CountryId = 1},
                new City { Id = 3, Name = "Lion", CountryId = 3},
                new City { Id = 4, Name = "Bordéus", CountryId = 3},
            });


        }
    }
}
