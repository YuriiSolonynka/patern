using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Models;

namespace patern.Services.Interface
{
    public interface ISecurityServiceService
    {
        IEnumerable<SecurityService> GetSecurityServices();
        SecurityService GetSecurityServiceById(int id);
        void CreateSecurityService(SecurityService securityService);
        void UpdateSecurityService(SecurityService securityService);
        void DeleteSecurityService(int id);
        void Save();
    }
}