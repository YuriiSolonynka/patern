using System.Collections.Generic;
using patern.Models;

namespace patern.Repositories.Interface
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<object> GetUsers();
        object GetUserById(int id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        void Save();
    }
}