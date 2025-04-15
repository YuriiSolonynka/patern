using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Models;
using patern.Services.Interface;
using patern.Repositories.Interface;

namespace patern.Services
{
    public class SecurityServiceService : ISecurityServiceService
    {
        private readonly ISecurityServiceRepository _securityServiceRepository;

        public SecurityServiceService(ISecurityServiceRepository securityServiceRepository)
        {
            _securityServiceRepository = securityServiceRepository;
        }

        public IEnumerable<object> GetSecurityServices()
        {
            return _securityServiceRepository.GetSecurityServices();
        }

        public object GetSecurityServiceById(int id)
        {
            return _securityServiceRepository.GetSecurityServiceById(id);
        }

        public void CreateSecurityService(SecurityService securityService)
        {
            _securityServiceRepository.InsertSecurityService(securityService);
            _securityServiceRepository.Save();
        }

        public void UpdateSecurityService(SecurityService securityService)
        {
            _securityServiceRepository.UpdateSecurityService(securityService);
            _securityServiceRepository.Save();
        }

        public void DeleteSecurityService(int id)
        {
            _securityServiceRepository.DeleteSecurityService(id);
            _securityServiceRepository.Save();
        }

        public void Save()
        {
            _securityServiceRepository.Save();
        }
    }
}