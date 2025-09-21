using CityBreaks.Web1.Data;
using CityBreaks.Web1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CityBreaks.Web1.Services;

namespace CityBreaks.Web1.Pages
{
    public class EditPropertyModel : PageModel
    {
        private readonly CityBreaksContext _context;
        private readonly IPropertyService _propertyService; 

        public EditPropertyModel(CityBreaksContext context)
        {
            _context = context;
            _propertyService = _propertyService; 
        }

        [BindProperty]
        public Property Property { get; set; }

        [BindProperty]
        public int? SelectedCountryId { get; set; }

        public SelectList Countries { get; set; }
        public SelectList Cities { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Property = await _context.Property
                .Include(p => p.City)
                .ThenInclude(c => c.Country)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (Property == null)
                return NotFound();

            // Define o país selecionado inicialmente
            SelectedCountryId = Property.City?.CountryId;

            await LoadSelectLists();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var propertyToUpdate = await _propertyService.GetByIdAsync(id);

            if (propertyToUpdate == null)
                return NotFound();

            if (await TryUpdateModelAsync<Property>(
                propertyToUpdate,
                "Property",
                p => p.Name,
                p => p.PricePerNight,
                p => p.CityId))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(propertyToUpdate.Id))
                        return NotFound();
                    else
                        throw;
                }
            }

            Property = propertyToUpdate;
            await LoadSelectLists();
            return Page();
        }

        public async Task<JsonResult> OnGetCitiesByCountryAsync(int countryId)
        {
            var cities = await _context.City
                .Where(c => c.CountryId == countryId)
                .Select(c => new { id = c.Id, name = c.Name })
                .ToListAsync();

            return new JsonResult(cities);
        }

        private bool PropertyExists(int id)
        {
            return _context.Property.Any(e => e.Id == id);
        }

        private async Task LoadSelectLists()
        {
            Countries = new SelectList(await _context.Countries.ToListAsync(), "Id", "CountryName", SelectedCountryId);

            if (SelectedCountryId != null)
            {
                Cities = new SelectList(
                    await _context.City
                        .Where(c => c.CountryId == SelectedCountryId)
                        .ToListAsync(),
                    "Id", "Name", Property.CityId);
            }
            else
            {
                Cities = new SelectList(new List<City>(), "Id", "Name");
            }
        }
    }
}
