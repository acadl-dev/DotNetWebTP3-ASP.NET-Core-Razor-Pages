namespace CityBreaks.Web1.Models
{
    public class Property
    {
        //  int Id, string Name, decimal PricePerNight, int CityId, City City

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerNight { get; set; }


        // Chave estrangeira
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
