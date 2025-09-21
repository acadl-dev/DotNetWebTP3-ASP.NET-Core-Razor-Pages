using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Web1.Models
{
    public class Property
    {
        //  int Id, string Name, decimal PricePerNight, int CityId, City City

        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; }
        public decimal PricePerNight { get; set; }


        // Chave estrangeira
        [Required(ErrorMessage = "A cidade é obrigatória")]
        public int CityId { get; set; }
        public City City { get; set; }

        // Soft Delete
        public DateTime? DeletedAt { get; set; }
    }
}
