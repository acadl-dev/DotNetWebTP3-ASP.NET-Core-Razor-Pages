namespace CityBreaks.Web1.Models
{
    public class Country
    {
        // int Id, string CountryCode, string CountryName

        public int Id { get; set; }
        public string CountryCode { get; set; }

        public string CountryName { get; set; }


        
        public List<City> Cities { get; set; }
    }
}
