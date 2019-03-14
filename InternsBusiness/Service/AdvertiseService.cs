using System.Collections.Generic;
using InternsDataAccessLayer.Entities;
using InternsDataAccessLayer.Repository;

namespace InternsServices.Service
{
    public class AdvertiseService : IAdvertiseService
    {
        private readonly IGenericRepository<Advertise> repository;

        public AdvertiseService(IGenericRepository<Advertise> repo)
        {
            repository = repo;
        }

        public IList<Advertise> GetAllAdvertises()
        {
            return repository.GetAll();
        }

        public Advertise GetAdvertiseById(int id)
        {
            return repository.GetById(id);
        }

        public void AddAdvertise(Advertise advertise)
        {
            if (advertise != null)
            {
                repository.Insert(advertise);
            }
        }

        public void DeleteAdvertise(int id)
        {
            repository.Delete(id);
        }

        public void EditAdvertise(Advertise advertise)
        {
            repository.Update(advertise);
        }
    }
}
