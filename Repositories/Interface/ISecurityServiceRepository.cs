using System.Collections.Generic;
using patern.Models;

namespace patern.Repositories.Interface
{
    public interface ISecurityServiceRepository : IDisposable
    {
        IEnumerable<object> GetSecurityServices();
        object GetSecurityServiceById(int id);
        void InsertSecurityService(SecurityService securityService);
        void UpdateSecurityService(SecurityService securityService);
        void DeleteSecurityService(int id);
        void Save();
    }
}