using System.Collections.Generic;

namespace matallurgical_plant.Services.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll(); // получение всех объектов

        T GetById(int id); // получение одного объекта по id

        void Create(T item); // создание объекта

        void Edit(int id, T item); // обновление объекта

        void Delete(int id); // удаление объекта по id
    }
}
