using System;
namespace Logic.BindingModels
{
    public class OrdersBM
    {
        public int Id { get; set; }
        public string PeopleName { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public string Remark { get; set; }
        public string ProductName { get; set; }
    }
}
