using System.Collections.Generic;
using System.ComponentModel;

namespace Logic.ViewModels
{
    public class WarehousesVM
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Название магазина")]
        public string ShopName { get; set; }
    }
}
