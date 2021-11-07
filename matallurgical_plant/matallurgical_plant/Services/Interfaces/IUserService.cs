using matallurgical_plant.Models;

namespace matallurgical_plant.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        public User GetByEmail(string email);

        public string GetRoleByEmail(string email);

        public User GetByLogin(string login);

        public bool IsEmailExist(string email);
    }
}
