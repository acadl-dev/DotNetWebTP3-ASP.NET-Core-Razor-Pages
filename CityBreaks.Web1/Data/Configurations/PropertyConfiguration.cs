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

        }
    }
}
