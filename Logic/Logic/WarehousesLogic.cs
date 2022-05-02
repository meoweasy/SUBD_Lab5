using Logic.BindingModels;
using Logic.Interfaces;
using Logic.ViewModels;
using System;
using System.Collections.Generic;

namespace Logic.Logic
{
    public class WarehousesLogic
    {
        private readonly IWarehousesStorage _classesStorage;
        public WarehousesLogic(IWarehousesStorage classesStorage)
        {
            _classesStorage = classesStorage;
        }
        public List<WarehousesVM> Read(WarehousesBM model)
        {
            if (model == null)
            {
                return _classesStorage.GetFullList();
            }
            if (model.Id > 0)
            {
                return new List<WarehousesVM> { _classesStorage.GetElement(model) };
            }
            return _classesStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(WarehousesBM model)
        {
            if (model.Id > 0)
            {
                _classesStorage.Update(model);
            }
            else
            {
                _classesStorage.Insert(model);
            }
        }
        public void Delete(WarehousesBM model)

        {
            var element = _classesStorage.GetElement(new WarehousesBM
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Склад не найден");
            }
            _classesStorage.Delete(model);
        }
    }
}
