using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Models;

namespace patern.Services.Interface
{
    public interface IUserService
    {
        IEnumerable<object> GetUsers();
        object GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        void Save();

    }
}