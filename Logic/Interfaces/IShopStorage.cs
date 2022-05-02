using Logic.BindingModels;
using Logic.ViewModels;
using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface IShopStorage
    {
        List<ShopVM> GetFullList();
        List<ShopVM> GetFilteredList(ShopBM model);
        ShopVM GetElement(ShopBM model);
        void Insert(ShopBM model);
        void Update(ShopBM model);
        void Delete(ShopBM model);
    }
}
