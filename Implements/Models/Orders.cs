using System;
using System.ComponentModel.DataAnnotations;

namespace Implements.Models
{
    public class Orders
    {
        public int Id { get; set; }
        [Required]
        public string PeopleName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
