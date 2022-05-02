using System.Collections.Generic;
using System.ComponentModel;

namespace Logic.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Название склада")]
        public string WarehouseName { get; set; }
    }
}
