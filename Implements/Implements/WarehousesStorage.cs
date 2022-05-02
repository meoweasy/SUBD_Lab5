using Logic.BindingModels;
using Logic.Interfaces;
using Logic.ViewModels;
using Implements.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Implements.Implements
{
    public class WarehousesStorage : IWarehousesStorage
    {
        public List<WarehousesVM> GetFullList()
        {
            using (var context = new DataBaseContext())
            {
                return context.Warehouses
                    .Include(rec => rec.Shop)
                .Select(CreateModel).ToList();
            }
        }

        public List<WarehousesVM> GetFilteredList(WarehousesBM model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DataBaseContext())
            {
                return context.Warehouses
                    .Include(rec => rec.Shop)
                    .Where(rec => rec.Name == model.Name)
                    .Select(CreateModel).ToList();
            }
        }

        public WarehousesVM GetElement(WarehousesBM model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DataBaseContext())
            {
                var classes = context.Warehouses
                    .Include(rec => rec.Shop)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return classes != null ?
                CreateModel(classes) : null;
            }
        }

        public void Insert(WarehousesBM model)
        {
            using (var context = new DataBaseContext())
            {
                context.Warehouses.Add(CreateModel(model, new Warehouses()));
                context.SaveChanges();
            }
        }

        public void Update(WarehousesBM model)
        {
            using (var context = new DataBaseContext())
            {
                Warehouses element = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Склад не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(WarehousesBM model)
        {
            using (var context = new DataBaseContext())
            {
                Warehouses element = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Warehouses.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Склад не найден");
                }
            }
        }

        private Warehouses CreateModel(WarehousesBM model, Warehouses classes)
        {
            classes.Name = model.Name;
            classes.ShopId = model.ShopId;
            return classes;
        }

        private WarehousesVM CreateModel(Warehouses classes)
        {
            return new WarehousesVM
            {
                Id = classes.Id,
                Name = classes.Name,
                ShopName = classes.Shop.Name
            };
        }

        public void UpdateEmployment(WarehousesBM model)
        {
            using (var context = new DataBaseContext())
            {
                Warehouses element = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Склад не найден");
                }
            }
        }
    }
}
