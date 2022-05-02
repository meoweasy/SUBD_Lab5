using System.ComponentModel;

namespace Logic.ViewModels
{
    public class ShopVM
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Номер магазина")]
        public int Shop_Number { get; set; }
        [DisplayName("Количество изделий")]
        public int Number_Of_Products { get; set; }
        [DisplayName("Название города")]
        public string CityName { get; set; }
    }
}
