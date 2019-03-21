using System.Linq;
using Interns.Core.Data;
using Interns.DataAccessLayer.Repository;
using Interns.Services.IService;

namespace Interns.Services.Service
{
    public class AdvertiseService : IAdvertiseService
    {
        private readonly IRepository<Advertise> repository;

        public AdvertiseService(IRepository<Advertise> repo)
        {
            repository = repo;
        }

        public IQueryable<Advertise> GetAdvertises()
        {
            return repository.GetAll();
        }

        public Advertise GetAdvertise(int id)
        {
            return repository.GetById(id);
        }

        public void InsertAdvertise(Advertise advertise)
        {
                repository.Insert(advertise);
        }

        public void DeleteAdvertise(Advertise advertise)
        {
            repository.Delete(advertise);
        }

        public void UpdateAdvertise(Advertise advertise)
        {
            repository.Update(advertise);
        }
    }
}
