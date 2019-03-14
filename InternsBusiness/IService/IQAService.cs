using System.Collections.Generic;
using InternsDataAccessLayer.Entities;

namespace InternsServices.Service
{
    public interface IQaService
    {
        IList<Qa> GetAllQas();
        Qa GetQAById(int id);
        void AddQa(Qa qa);
        void DeleteQa(int id);
        void EditQa(Qa qa);
    }
}