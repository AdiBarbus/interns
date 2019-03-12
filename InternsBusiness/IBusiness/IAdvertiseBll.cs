using System.Collections.Generic;
using InternsDataAccessLayer.Entities;

namespace InternsBusiness.Business
{
    public interface IAdvertiseBll
    {
        IList<Advertise> GetAllAdvertises();
        Advertise GetAdvertiseById(int id);
        void AddAdvertise(Advertise advertise);
        void DeleteAdvertise(int id);
        void EditAdvertise(Advertise advertise);
    }
}