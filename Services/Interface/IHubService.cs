using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Models;

namespace patern.Services.Interface
{
    public interface IHubService
    {
        IEnumerable<object> GetHubs();
        object GetHubById(int id);
        void CreateHub(Hub hub);
        void UpdateHub(Hub hub);
        void DeleteHub(int id);
        void Save();
    }
}