using CityBreaks.Web1.Models;
using CityBreaks.Web1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web1.Pages
{
    public class FilterPropertiesModel : PageModel
    {
        private readonly IPropertyService _propertyService;

        public FilterPropertiesModel(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [BindProperty(SupportsGet = true)]
        public decimal? MinPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? MaxPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CityName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PropertyName { get; set; }

        public List<Property> Properties { get; set; } = new List<Property>();
        public bool HasFilters => MinPrice.HasValue || MaxPrice.HasValue ||
                                 !string.IsNullOrWhiteSpace(CityName) ||
                                 !string.IsNullOrWhiteSpace(PropertyName);

        public async Task OnGetAsync()
        {
            Properties = await _propertyService.GetFilteredAsync(MinPrice, MaxPrice, CityName, PropertyName);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Redireciona para GET com os parâmetros na URL
            var routeValues = new Dictionary<string, object>();

            if (MinPrice.HasValue)
                routeValues["MinPrice"] = MinPrice.Value;

            if (MaxPrice.HasValue)
                routeValues["MaxPrice"] = MaxPrice.Value;

            if (!string.IsNullOrWhiteSpace(CityName))
                routeValues["CityName"] = CityName;

            if (!string.IsNullOrWhiteSpace(PropertyName))
                routeValues["PropertyName"] = PropertyName;

            return RedirectToPage(routeValues);
        }

        public string GetAppliedFiltersDescription()
        {
            var filters = new List<string>();

            if (MinPrice.HasValue)
                filters.Add($"Preço mínimo: R$ {MinPrice:F2}");

            if (MaxPrice.HasValue)
                filters.Add($"Preço máximo: R$ {MaxPrice:F2}");

            if (!string.IsNullOrWhiteSpace(CityName))
                filters.Add($"Cidade: {CityName}");

            if (!string.IsNullOrWhiteSpace(PropertyName))
                filters.Add($"Propriedade: {PropertyName}");

            return filters.Any() ? string.Join(" | ", filters) : "Nenhum filtro aplicado";
        }
    }
}