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
                .Include(c => c.Country)      // Inclui o país da cidade
                .Include(c => c.Properties)   // Inclui as propriedades da cidade
                .ToListAsync();
        }
    }
}
