using System.ComponentModel.DataAnnotations;

namespace Implements.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int WarehouseId { get; set; }
        public virtual Warehouses Warehouse { get; set; }
    }
}
