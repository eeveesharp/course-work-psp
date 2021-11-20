using matallurgical_plant.Domain;
using matallurgical_plant.Models;
using matallurgical_plant.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace matallurgical_plant.Services.Emplimentation
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            User user = _db.Users.Where(user => user.Id == id).FirstOrDefault();
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public void Edit(int id, User item)
        {
            _db.Users.Update(item);
            _db.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User GetById(int id)
        {
            return _db.Users.Where(user => user.Id == id).FirstOrDefault();
        }

        public void Create(User item)
        {
            _db.Users.Add(item);
            _db.SaveChanges();
        }
    }   
}
