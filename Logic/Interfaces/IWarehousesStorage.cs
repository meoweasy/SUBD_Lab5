using Logic.BindingModels;
using Logic.ViewModels;
using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface IWarehousesStorage
    {
        List<WarehousesVM> GetFullList();
        List<WarehousesVM> GetFilteredList(WarehousesBM model);
        WarehousesVM GetElement(WarehousesBM model);
        void Insert(WarehousesBM model);
        void Update(WarehousesBM model);
        void Delete(WarehousesBM model);
    }
}
