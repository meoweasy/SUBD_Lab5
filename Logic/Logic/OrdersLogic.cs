using Logic.BindingModels;
using Logic.Interfaces;
using Logic.ViewModels;
using System;
using System.Collections.Generic;

namespace Logic.Logic
{
    public class OrdersLogic
    {
        private readonly IOrdersStorage _advancementsStorage;
        public OrdersLogic(IOrdersStorage advancementsStorage)
        {
            _advancementsStorage = advancementsStorage;
        }
        public List<OrdersVM> Read(OrdersBM model)
        {
            if (model == null)
            {
                return _advancementsStorage.GetFullList();
            }
            if (model.Id > 0)
            {
                return new List<OrdersVM> { _advancementsStorage.GetElement(model) };
            }
            return _advancementsStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(OrdersBM model)
        {
            if (model.Id > 0)
            {
                _advancementsStorage.Update(model);
            }
            else
            {
                _advancementsStorage.Insert(model);
            }
        }
        public void Delete(OrdersBM model)

        {
            var element = _advancementsStorage.GetElement(new OrdersBM
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Изделие не найдено");
            }
            _advancementsStorage.Delete(model);
        }
    }
}
