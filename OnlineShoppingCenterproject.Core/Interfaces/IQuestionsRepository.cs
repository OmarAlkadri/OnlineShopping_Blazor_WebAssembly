using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Interfaces
{
    public interface IQuestionsRepository : IRepository<Questions>
    {
        Task<List<Questions>> GetAllQuestionsForCompany(Guid CompanyId);
        Task<List<Questions>> GetAllQuestionsForProduct(Guid ProductId);
        Task<Questions> GetQuestionsById(Guid QuestionId);
        void CreateQuestions(Questions entity);
        void UpdateQuestions(Questions entity);
        void DeleteQuestions(Questions entity);
    }
}
