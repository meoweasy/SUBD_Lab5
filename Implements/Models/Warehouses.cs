using System.ComponentModel.DataAnnotations;

namespace Implements.Models
{
    public class Warehouses
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
