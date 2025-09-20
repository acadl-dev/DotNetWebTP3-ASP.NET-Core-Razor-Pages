using CityBreaks.Web1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CityBreaks.Web1.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id_property");
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.HasData(new List<Property> {
                new Property { Id = 1, Name = "Santa Grelha", PricePerNight = 210.20M, CityId = 1},
                new Property { Id = 2, Name = "Moleska Gastrobar", PricePerNight = 230.90M, CityId = 2},
                new Property { Id = 3, Name = "Bouchon Fiston", PricePerNight = 300.00M, CityId = 3},
                new Property { Id = 4, Name = "Les Pavès de Saint Jean", PricePerNight = 390.90M, CityId = 3}
            });

        }
    }
}
