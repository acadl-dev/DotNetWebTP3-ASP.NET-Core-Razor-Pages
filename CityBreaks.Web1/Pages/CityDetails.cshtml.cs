using CityBreaks.Web1.Interfaces;
using CityBreaks.Web1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace CityBreaks.Web1.Pages
{
    public class Index1Model : PageModel
    {
        private readonly ICityService _cityService;

        public Index1Model(ICityService cityService)
        {
            _cityService = cityService;
        }

        public City? City { get; set; }

        public async Task<IActionResult> OnGetAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return NotFound();
            }

            City = await _cityService.GetByNameAsync(name);

            if (City == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
