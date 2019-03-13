using System.Collections.Generic;
using InternsDataAccessLayer.Entities;
using InternsDataAccessLayer.Repository;

namespace InternsBusiness.Business
{
    public class AdvertiseBll : IAdvertiseBll
    {
        private readonly IAdvertiseRepository repository;

        public AdvertiseBll(IAdvertiseRepository repo)
        {
            repository = repo;
        }

        public IList<Advertise> GetAllAdvertises()
        {
            return repository.GetAll();
        }

        public Advertise GetAdvertiseById(int id)
        {
            return repository.GetById(a => a.Id == id);
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
