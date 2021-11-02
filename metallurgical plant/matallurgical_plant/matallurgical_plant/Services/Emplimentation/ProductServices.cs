using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using matallurgical_plant.Models;
using matallurgical_plant.Services.Interfaces;

namespace matallurgical_plant.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductServices productServices;

        public Product Create(Product item)
        {
            return productServices.Create(item);
        }

        public bool Delete(int id)
        {
            return productServices.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return productServices.GetAll();
        }

        public Product GetById(int id)
        {
            return productServices.GetById(id);
        }

        public Product Update(int id, Product item)
        {
            return productServices.Update(id, item);
        }
    }
}
