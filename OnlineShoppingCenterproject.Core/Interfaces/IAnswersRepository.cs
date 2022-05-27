using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Interfaces
{
    public interface IAnswersRepository : IRepository<Answers>
    {
        Task<List<Answers>> GetAllAnswers(Guid CompanyId);
        Task<Answers> GetAnswersById(Guid Id);
        void CreateAnswers(Answers entity);
        void UpdateAnswers(Answers entity);
        void DeleteAnswers(Answers entity);
    }
}
