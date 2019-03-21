using System.Linq;
using Interns.Core.Data;
using Interns.DataAccessLayer.Repository;
using Interns.Services.IService;

namespace Interns.Services.Service
{
    public class QAService : IQaService
    {
        private readonly IRepository<Qa> repository;

        public QAService(IRepository<Qa> repo)
        {
            repository = repo;
        }

        public IQueryable<Qa> GetQas()
        {
            return repository.GetAll();
        }

        public Qa GetQa(int id)
        {
            return repository.GetById(id); //a => a.Id == id);
        }

        public void InsertQa(Qa qa)
        {
            if (qa != null)
            {
                repository.Insert(qa);
            }
        }

        public void DeleteQa(Qa qa)
        {
            repository.Delete(qa);
        }

        public void UpdateQa(Qa qa)
        {
            repository.Update(qa);
        }
    }
}
