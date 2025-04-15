using System.Collections.Generic;
using patern.Models;

namespace patern.Repositories.Interface
{
    public interface IHubRepository : IDisposable
    {
        IEnumerable<object> GetHubs();
        object GetHubById(int id);
        void InsertHub(Hub hub);
        void UpdateHub(Hub hub);
        void DeleteHub (int id);
        void Save();
    }
}