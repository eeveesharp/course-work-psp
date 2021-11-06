using matallurgical_plant.Domain;
using matallurgical_plant.Models;
using matallurgical_plant.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace matallurgical_plant.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _db;

        public ProductService(AppDbContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            Product product = _db.Products.Where(product => product.Id == id).FirstOrDefault();
            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        public void Edit(int id, Product item)
        {
            Product product = _db.Products
        .Include(i => item.Material == i.Material)
        .Include(i => item.NameProduct == i.NameProduct)
        .Include(i => item.Price == i.Price)
        .Include(i => item.Quantity == i.Quantity)
        .Where(i => i.Id == id)
        .Single();

            _db.Update(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Products.ToList();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Product item)
        {
            throw new NotImplementedException();
        }

        public void Add()
        {
            throw new NotImplementedException();
        }
    }
}
