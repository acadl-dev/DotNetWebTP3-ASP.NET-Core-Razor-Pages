using CityBreaks.Web1.Data;
using CityBreaks.Web1.Interfaces;
using CityBreaks.Web1.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web1.Services
{
    public class CityService : ICityService
    {
        private readonly CityBreaksContext _context;

        public CityService(CityBreaksContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await _context.City
                .Include(c => c.Country)
                .Select(c => new City
                {
                    Id = c.Id,
                    Name = c.Name,
                    CountryId = c.CountryId,
                    Country = c.Country,
                    Properties = c.Properties
                        .Where(p => p.DeletedAt == null) // 👈 só propriedades ativas
                        .ToList()
                })
                .ToListAsync();
        }

        public async Task<City?> GetByNameAsync(string name)
        {
            return await _context.City
                .Include(c => c.Country)
                .Select(c => new City
                {
                    Id = c.Id,
                    Name = c.Name,
                    CountryId = c.CountryId,
                    Country = c.Country,
                    Properties = c.Properties
                        .Where(p => p.DeletedAt == null) // 👈 só propriedades ativas
                        .ToList()
                })
                .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }
    }
}
