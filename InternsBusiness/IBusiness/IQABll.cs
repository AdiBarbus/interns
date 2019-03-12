using System.Collections.Generic;
using InternsDataAccessLayer.Entities;

namespace InternsBusiness.Business
{
    public interface IQABll
    {
        IList<QA> GetAllQAs();
        QA GetQAById(int id);
        void AddQA(QA qa);
        void DeleteQA(int id);
        void EditQA(QA qa);
    }
}