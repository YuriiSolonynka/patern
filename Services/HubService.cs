using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patern.Models;
using patern.Services.Interface;
using patern.Repositories.Interface;


namespace patern.Services
{
    public class HubService : IHubService
    {
        private readonly IHubRepository _hubRepository;

        public HubService(IHubRepository hubRepository)
        {
            _hubRepository = hubRepository;
        }

        public IEnumerable<Hub> GetHubs()
        {
            return _hubRepository.GetHubs();
        }

        public Hub GetHubById(int id)
        {
            return _hubRepository.GetHubById(id);
        }

        public void CreateHub(Hub hub)
        {
            _hubRepository.InsertHub(hub);
            _hubRepository.Save();
        }

        public void UpdateHub(Hub hub)
        {
            _hubRepository.UpdateHub(hub);
            _hubRepository.Save();
        }

        public void DeleteHub(int id)
        {
            _hubRepository.DeleteHub(id);
            _hubRepository.Save();
        }

        public void Save()
        {
            _hubRepository.Save();
        }
    }
}