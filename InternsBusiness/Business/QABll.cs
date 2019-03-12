using System.Collections.Generic;
using InternsDataAccessLayer.Entities;
using InternsDataAccessLayer.Repository;

namespace InternsBusiness.Business
{
    public class QABll : IQABll
    {
        private readonly IQaRepository repository;

        public QABll(IQaRepository repo)
        {
            repository = repo;
        }

        public IList<QA> GetAllQAs()
        {
            return repository.GetAll();
        }

        public QA GetQAById(int id)
        {
            return repository.GetById(a => a.Id == id);
        }

        public void AddQA(QA qa)
        {
            if (qa != null)
            {
                repository.Insert(qa);
            }
        }

        public void DeleteQA(int id)
        {
            repository.Delete(id);
        }

        public void EditQA(QA qa)
        {
            repository.Update(qa);
        }
    }
}
