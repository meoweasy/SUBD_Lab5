using Logic.BindingModels;
using Logic.Interfaces;
using Logic.ViewModels;
using System;
using System.Collections.Generic;

namespace Logic.Logic
{
    public class ProductLogic
    {
        private readonly IProductStorage _studentStorage;
        public ProductLogic(IProductStorage studentStorage)
        {
            _studentStorage = studentStorage;
        }
        public List<ProductVM> Read(ProductBM model)
        {
            if (model == null)
            {
                return _studentStorage.GetFullList();
            }
            if (model.Id > 0)
            {
                return new List<ProductVM> { _studentStorage.GetElement(model) };
            }
            return _studentStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ProductBM model)
        {
            if (model.Id > 0)
            {
                _studentStorage.Update(model);
            }
            else
            {
                _studentStorage.Insert(model);
            }
        }
        public void Delete(ProductBM model)

        {
            var element = _studentStorage.GetElement(new ProductBM
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Изделие не найдено");
            }
            _studentStorage.Delete(model);
        }
    }
}
