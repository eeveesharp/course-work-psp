using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matallurgical_plant.Services.Interfaces
{
    interface IServices<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        T Create(T item);

        T Update(int id, T item);

        bool Delete(int id);
    }
}
