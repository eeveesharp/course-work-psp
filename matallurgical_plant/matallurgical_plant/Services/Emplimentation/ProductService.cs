using ClosedXML.Excel;
using matallurgical_plant.Domain;
using matallurgical_plant.Models;
using matallurgical_plant.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            _db.Products.Update(item);
            _db.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _db.Products.Where(product => product.Id == id).FirstOrDefault();
        }

        public void Create(Product item)
        {
            _db.Products.Add(item);
            _db.SaveChanges();
        }
    }
}
