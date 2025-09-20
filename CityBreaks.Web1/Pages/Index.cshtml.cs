using CityBreaks.Web1.Interfaces;
using CityBreaks.Web1.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICityService _cityService;

        public IndexModel(ICityService cityService)
        {
            _cityService = cityService;
        }

        public List<City> Cities { get; set; } = new();

        public async Task OnGetAsync()
        {
            Cities = await _cityService.GetAllAsync();
        }
    }
}
