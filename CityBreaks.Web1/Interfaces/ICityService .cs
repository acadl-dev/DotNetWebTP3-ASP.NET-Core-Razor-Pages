using CityBreaks.Web1.Models;

namespace CityBreaks.Web1.Interfaces
{
    public interface ICityService
    {
        Task<List<City>> GetAllAsync();
        Task<City?> GetByNameAsync(string name);
    }
}
