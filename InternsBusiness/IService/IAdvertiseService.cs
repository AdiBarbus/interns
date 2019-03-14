using System.Collections.Generic;
using InternsDataAccessLayer.Entities;

namespace InternsServices.Service
{
    public interface IAdvertiseService
    {
        IList<Advertise> GetAllAdvertises();
        Advertise GetAdvertiseById(int id);
        void AddAdvertise(Advertise advertise);
        void DeleteAdvertise(int id);
        void EditAdvertise(Advertise advertise);
    }
}