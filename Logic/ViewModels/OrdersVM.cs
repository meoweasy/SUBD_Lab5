using System;
using System.ComponentModel;

namespace Logic.ViewModels
{
    public class OrdersVM
    {
        public int Id { get; set; }

        [DisplayName("Имя заказчика")]
        public string PeopleName { get; set; }
        [DisplayName("Цена")]
        public int Price { get; set; }
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        [DisplayName("Комментарий")]
        public string Remark { get; set; }
        [DisplayName("Изделие")]
        public string ProductName { get; set; }
    }
}
