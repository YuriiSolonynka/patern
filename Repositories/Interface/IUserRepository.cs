using System.Collections.Generic;
using patern.Models;

namespace patern.Repositories.Interface
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        void Save();
    }
}