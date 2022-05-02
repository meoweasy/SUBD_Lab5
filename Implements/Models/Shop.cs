using System.ComponentModel.DataAnnotations;

namespace Implements.Models
{
    public class Shop
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Shop_Number { get; set; }
        [Required]
        public int Number_Of_Products { get; set; }
        [Required]
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
