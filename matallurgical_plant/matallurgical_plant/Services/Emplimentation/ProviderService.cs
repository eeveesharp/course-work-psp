using matallurgical_plant.Domain;
using matallurgical_plant.Models;
using matallurgical_plant.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace matallurgical_plant.Services.Emplimentation
{
    public class ProviderService : IProviderService
    {
        private readonly AppDbContext _db;

        public ProviderService(AppDbContext db)
        {
            _db = db;
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Create(Provider item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Provider> GetAll()
        {
            throw new NotImplementedException();
        }

        public Provider GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id,Provider item)
        {
            throw new NotImplementedException();
        }
    }
}
