using CityBreaks.Web1.Data;
using CityBreaks.Web1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web1.Pages
{
    public class CreatePropertyModel : PageModel
    {
        private readonly CityBreaksContext _context;

        public CreatePropertyModel(CityBreaksContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Property Property { get; set; } = new Property();

        public SelectList CityList { get; set; } = null!;

        public async Task OnGetAsync()
        {
            await LoadCitiesAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("Entrou no POST");

            // Remove a validação da propriedade de navegação City
            ModelState.Remove("Property.City");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("Entrou no IF do POST");
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine($"Erro em {key}: {error.ErrorMessage}");
                    }
                }

                // Recarregar a lista de cidades em caso de erro
                await LoadCitiesAsync();
                return Page();
            }

            await _context.Property.AddAsync(Property);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }

        private async Task LoadCitiesAsync()
        {
            var cities = await _context.City
                .OrderBy(c => c.Name)
                .ToListAsync();
            CityList = new SelectList(cities, "Id", "Name");
        }
    }
}