using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Models;
using patern.Services.Interface;
using patern.Repositories.Interface;

namespace patern.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public void CreateUser(User user)
        {
            _userRepository.InsertUser(user);
            _userRepository.Save();
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
            _userRepository.Save();
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
            _userRepository.Save();
        }

        public void Save()
        {
            _userRepository.Save();
        }
    }
}