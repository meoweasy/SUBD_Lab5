using Logic.BindingModels;
using Logic.Interfaces;
using Logic.ViewModels;
using System;
using System.Collections.Generic;

namespace Logic.Logic
{
    public class ShopLogic
    {
        private readonly IShopStorage _schoolStorage;
        public ShopLogic(IShopStorage schoolStorage)
        {
            _schoolStorage = schoolStorage;
        }
        public List<ShopVM> Read(ShopBM model)
        {
            if (model == null)
            {
                return _schoolStorage.GetFullList();
            }
            if (model.Id > 0)
            {
                return new List<ShopVM> { _schoolStorage.GetElement(model) };
            }
            return _schoolStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ShopBM model)
        {
            if (model.Id > 0)
            {
                _schoolStorage.Update(model);
            }
            else
            {
                _schoolStorage.Insert(model);
            }
        }
        public void Delete(ShopBM model)

        {
            var element = _schoolStorage.GetElement(new ShopBM
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Магазин не найден");
            }
            _schoolStorage.Delete(model);
        }
    }
}
