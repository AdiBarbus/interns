using System.Collections.Generic;
using InternsDataAccessLayer.Entities;

namespace InternsServices.Service
{
    public interface IAddressService
    {
        IList<Address> GetAllAddresses();
        Address GetAddressById(int id);
        void AddAddress(Address address);
        void DeleteAddress(int id);
        void EditAddress(Address address);
        void Save();
    }
}