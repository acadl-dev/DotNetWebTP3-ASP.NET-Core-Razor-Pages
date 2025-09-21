using CityBreaks.Web1.Data;
using CityBreaks.Web1.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web1.Services
{
    public interface IPropertyService
    {
        Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string cityName, string propertyName);
        Task<List<Property>> GetAllActiveAsync();
        Task<Property> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }

    public class PropertyService : IPropertyService
    {
        private readonly CityBreaksContext _context;

        public PropertyService(CityBreaksContext context)
        {
            _context = context;
        }

        public async Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string cityName, string propertyName)
        {
            // Inicia a query com apenas propriedades ativas (não deletadas)
            IQueryable<Property> query = _context.Property
                .Include(p => p.City)
                .ThenInclude(c => c.Country)
                .Where(p => p.DeletedAt == null); // Ignora registros deletados

            // Aplica filtro de preço mínimo se informado
            if (minPrice.HasValue)
            {
                query = query.Where(p => p.PricePerNight >= minPrice.Value);
            }

            // Aplica filtro de preço máximo se informado
            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.PricePerNight <= maxPrice.Value);
            }

            // Aplica filtro de cidade se informado
            if (!string.IsNullOrWhiteSpace(cityName))
            {
                query = query.Where(p => p.City.Name.Contains(cityName));
            }

            // Aplica filtro de nome da propriedade se informado
            if (!string.IsNullOrWhiteSpace(propertyName))
            {
                query = query.Where(p => p.Name.Contains(propertyName));
            }

            // Ordena por nome da propriedade
            query = query.OrderBy(p => p.Name);

            return await query.ToListAsync();
        }

        public async Task<List<Property>> GetAllActiveAsync()
        {
            return await _context.Property
                .Include(p => p.City)
                .ThenInclude(c => c.Country)
                .Where(p => p.DeletedAt == null) // Apenas propriedades ativas
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<Property> GetByIdAsync(int id)
        {
            return await _context.Property
                .Include(p => p.City)
                .ThenInclude(c => c.Country)
                .Where(p => p.DeletedAt == null) // Apenas se não foi deletada
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var property = await _context.Property.FindAsync(id);

            if (property != null && property.DeletedAt == null)
            {
                // Soft delete - apenas preenche a data de deleção
                property.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }
    }
}