namespace CityBreaks.Web1.Models
{
    public class City
    {
        // int Id, string Name, int CountryId, Country Country

        public int Id { get; set; }
        public string Name { get; set; }

        // Chave estrangeira
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public List<Property> Properties { get; set; }


    }
}

