using System.Collections.Generic;
using InternsDataAccessLayer.Entities;
using InternsDataAccessLayer.Repository;
using InternsServices.IService;

namespace InternsServices.Service
{
    public class QAService : IQaService
    {
        private readonly IGenericRepository<Qa> repository;

        public QAService(IGenericRepository<Qa> repo)
        {
            repository = repo;
        }

        public IList<Qa> GetAllQas()
        {
            return repository.GetAll();
        }

        public Qa GetQAById(int id)
        {
            return repository.GetById(id); //a => a.Id == id);
        }

        public void AddQa(Qa qa)
        {
            if (qa != null)
            {
                repository.Insert(qa);
            }
        }

        public void DeleteQa(int id)
        {
            repository.Delete(id);
        }

        public void EditQa(Qa qa)
        {
            repository.Update(qa);
        }
    }
}
