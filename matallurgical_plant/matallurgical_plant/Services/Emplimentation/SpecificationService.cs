using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using matallurgical_plant.Domain;
using matallurgical_plant.Models;
using matallurgical_plant.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace matallurgical_plant.Services.Emplimentation
{
    public class SpecificationService : ISpecificationService
    {
         private readonly AppDbContext _db;

        public SpecificationService(AppDbContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            Specification specification = _db.Spetifications.Where(specification => specification.Id == id).FirstOrDefault();
            _db.Spetifications.Remove(specification);
            _db.SaveChanges();
        }

        public void Edit(int id, Specification item)
        {
            _db.Spetifications.Update(item);
            _db.SaveChanges();
        }

        public IEnumerable<Specification> GetAll()
        {
            return _db.Spetifications.ToList();
        }

        public Specification GetById(int id)
        {
            return _db.Spetifications.Where(specification => specification.Id == id).Include(x => x.Product).FirstOrDefault();
        }

        public void Create(Specification item)
        {
            _db.Spetifications.Add(item);
            _db.SaveChanges();
        }
    }
}
