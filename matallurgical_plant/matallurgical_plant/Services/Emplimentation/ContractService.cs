using matallurgical_plant.Domain;
using matallurgical_plant.Models;
using matallurgical_plant.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace matallurgical_plant.Services.Emplimentation
{
    public class ContractService : IContractService
    {
        private readonly AppDbContext _db;

        public ContractService(AppDbContext db)
        {
            _db = db;
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Create(Contract item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contract> GetAll()
        {
            throw new NotImplementedException();
        }

        public Contract GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Contract item)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id, Contract item)
        {
            throw new NotImplementedException();
        }
    }
}
