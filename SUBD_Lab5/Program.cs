using Logic.Logic;
using Logic.Interfaces;
using Implements.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace SUBD_Lab5
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<MainForm>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ICityStorage, CityStorage>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IShopStorage, ShopStorage>(new
          HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductStorage, ProductStorage>(new
          HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWarehousesStorage, WarehousesStorage>(new
          HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrdersStorage, OrdersStorage>(new
          HierarchicalLifetimeManager());
            currentContainer.RegisterType<CityLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<ShopLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<WarehousesLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<OrdersLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<ProductLogic>(new
           HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
