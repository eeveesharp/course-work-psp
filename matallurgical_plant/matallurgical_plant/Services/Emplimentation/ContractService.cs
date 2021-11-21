using matallurgical_plant.Domain;
using matallurgical_plant.Models;
using matallurgical_plant.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace matallurgical_plant.Services.Emplimentation
{
    public class ContractService : IContractService
    {
        private readonly AppDbContext _db;

        public ContractService(AppDbContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            Contract contract = _db.Contracts.Where(contract => contract.Id == id).FirstOrDefault();
            _db.Contracts.Remove(contract);
            _db.SaveChanges();
        }

        public void Edit(int id, Contract item)
        {
            _db.Contracts.Update(item);
            _db.SaveChanges();
        }

        public IEnumerable<Contract> GetAll()
        {
            return _db.Contracts.ToList();
        }

        public Contract GetById(int id)
        {
            return _db.Contracts.Where(contract => contract.Id == id).FirstOrDefault();
        }

        public void Create(Contract item)
        {
            _db.Contracts.Add(item);
            _db.SaveChanges();
        }
    }
}
