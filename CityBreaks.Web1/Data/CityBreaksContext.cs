using CityBreaks.Web1.Data.Configurations;
using CityBreaks.Web1.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;


namespace CityBreaks.Web1.Data
{
    public class CityBreaksContext : DbContext
    {
        public CityBreaksContext(DbContextOptions<CityBreaksContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new AlunoConfigurations());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
            
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<City> Property { get; set; }
    }
}
