using System.Collections.Generic;
using InternsDataAccessLayer.Entities;

namespace InternsServices.IService
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