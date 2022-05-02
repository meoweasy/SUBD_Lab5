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
    public class ProductStorage : IProductStorage
    {
        public List<ProductVM> GetFullList()
        {
            using (var context = new DataBaseContext())
            {
                return context.Products
                    .Include(rec => rec.Warehouse)
                .Select(CreateModel).ToList();
            }
        }

        public List<ProductVM> GetFilteredList(ProductBM model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DataBaseContext())
            {
                return context.Products
                    .Include(rec => rec.Warehouse)
                    .Where(rec => rec.WarehouseId == model.WarehouseId)
                    .Select(CreateModel).ToList();
            }
        }

        public ProductVM GetElement(ProductBM model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DataBaseContext())
            {
                var student = context.Products
                    .Include(rec => rec.Warehouse)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return student != null ?
                CreateModel(student) : null;
            }
        }

        public void Insert(ProductBM model)
        {
            using (var context = new DataBaseContext())
            {
                context.Products.Add(CreateModel(model, new Product()));
                context.SaveChanges();
            }
        }

        public void Update(ProductBM model)
        {
            using (var context = new DataBaseContext())
            {
                Product element = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Изделие не найдено");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(ProductBM model)
        {
            using (var context = new DataBaseContext())
            {
                Product element = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Products.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Изделие не найдено");
                }
            }
        }

        private Product CreateModel(ProductBM model, Product student)
        {
            student.Name = model.Name;
            student.WarehouseId = model.WarehouseId;
            return student;
        }

        private ProductVM CreateModel(Product student)
        {
            return new ProductVM
            {
                Id = student.Id,
                Name = student.Name,
                WarehouseName = student.Warehouse.Name
            };
        }

        public void UpdateEmployment(ProductBM model)
        {
            using (var context = new DataBaseContext())
            {
                Product element = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Студент не найден");
                }
            }
        }
    }
}
