using Logic.BindingModels;
using Logic.ViewModels;
using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface IProductStorage
    {
        List<ProductVM> GetFullList();
        List<ProductVM> GetFilteredList(ProductBM model);
        ProductVM GetElement(ProductBM model);
        void Insert(ProductBM model);
        void Update(ProductBM model);
        void Delete(ProductBM model);
    }
}
