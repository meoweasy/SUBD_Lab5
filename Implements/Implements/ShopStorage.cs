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
    public class ShopStorage : IShopStorage
    {
        public List<ShopVM> GetFullList()
        {
            using (var context = new DataBaseContext())
            {
                return context.Shops
                    .Include(rec => rec.City)
                .Select(CreateModel).ToList();
            }
        }

        public List<ShopVM> GetFilteredList(ShopBM model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DataBaseContext())
            {
                return context.Shops
                    .Include(rec => rec.City)
                    .Where(rec => rec.Name == model.Name)
                    .Select(CreateModel).ToList();
            }
        }

        public ShopVM GetElement(ShopBM model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DataBaseContext())
            {
                var school = context.Shops
                    .Include(rec => rec.City)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return school != null ?
                CreateModel(school) : null;
            }
        }

        public void Insert(ShopBM model)
        {
            using (var context = new DataBaseContext())
            {
                context.Shops.Add(CreateModel(model, new Shop()));
                context.SaveChanges();
            }
        }

        public void Update(ShopBM model)
        {
            using (var context = new DataBaseContext())
            {
                Shop element = context.Shops.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Магазин не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(ShopBM model)
        {
            using (var context = new DataBaseContext())
            {
                Shop element = context.Shops.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Shops.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Магазин не найден");
                }
            }
        }

        private Shop CreateModel(ShopBM model, Shop school)
        {
            school.Name = model.Name;
            school.Shop_Number = model.Shop_Number;
            school.Number_Of_Products = model.Number_Of_Products;
            school.CityId = model.CityId;
            return school;
        }

        private ShopVM CreateModel(Shop school)
        {
            return new ShopVM
            {
                Id = school.Id,
                Name = school.Name,
                Shop_Number = school.Shop_Number,
                Number_Of_Products = school.Number_Of_Products,
                CityName = school.City.Initials
            };
        }

        public void UpdateEmployment(ShopBM model)
        {
            using (var context = new DataBaseContext())
            {
                Shop element = context.Shops.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Магазин не найден");
                }
            }
        }
    }
}
