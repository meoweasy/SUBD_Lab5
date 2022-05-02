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
    public class OrdersStorage : IOrdersStorage
    {
        public List<OrdersVM> GetFullList()
        {
            using (var context = new DataBaseContext())
            {
                return context.Orders
                    .Include(rec => rec.Product)
                .Select(CreateModel).ToList();
            }
        }

        public List<OrdersVM> GetFilteredList(OrdersBM model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DataBaseContext())
            {
                return context.Orders
                    .Include(rec => rec.Product)
                    .Where(rec => rec.Price == model.Price)
                    .Select(CreateModel).ToList();
            }
        }

        public OrdersVM GetElement(OrdersBM model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DataBaseContext())
            {
                var advancements = context.Orders
                    .Include(rec => rec.Product)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return advancements != null ?
                CreateModel(advancements) : null;
            }
        }

        public void Insert(OrdersBM model)
        {
            using (var context = new DataBaseContext())
            {
                context.Orders.Add(CreateModel(model, new Orders()));
                context.SaveChanges();
            }
        }

        public void Update(OrdersBM model)
        {
            using (var context = new DataBaseContext())
            {
                Orders element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Заказ не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(OrdersBM model)
        {
            using (var context = new DataBaseContext())
            {
                Orders element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Заказ не найден");
                }
            }
        }

        private Orders CreateModel(OrdersBM model, Orders advancements)
        {
            advancements.PeopleName = model.PeopleName;
            advancements.Price = model.Price;
            advancements.Date = model.Date;
            advancements.ProductId = model.ProductId;
            return advancements;
        }

        private OrdersVM CreateModel(Orders advancements)
        {
            return new OrdersVM
            {
                Id = advancements.Id,
                PeopleName = advancements.PeopleName,
                Price = advancements.Price,
                Date = advancements.Date,
                ProductName = advancements.Product.Name
            };
        }

        public void UpdateEmployment(OrdersBM model)
        {
            using (var context = new DataBaseContext())
            {
                Orders element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Заказ не найден");
                }
            }
        }
    }
}
