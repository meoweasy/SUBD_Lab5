using Logic.BindingModels;
using Logic.ViewModels;
using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface IOrdersStorage
    {
        List<OrdersVM> GetFullList();
        List<OrdersVM> GetFilteredList(OrdersBM model);
        OrdersVM GetElement(OrdersBM model);
        void Insert(OrdersBM model);
        void Update(OrdersBM model);
        void Delete(OrdersBM model);
    }
}
