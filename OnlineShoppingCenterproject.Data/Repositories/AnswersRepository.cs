using Microsoft.EntityFrameworkCore;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;
using OnlineShoppingCenterproject.Data_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Data.Repositories
{
    public class AnswersRepository : RepositoryBase<Answers>, IAnswersRepository
    {
        public AnswersRepository(Context_DB Context) : base(Context)
        {

        }
        public async Task<List<Answers>> GetAllAnswers(Guid QuestionsId)
        {
            return await(from data in Context.Answers
                         where data.QuestionsId == QuestionsId
                         select data).ToListAsync();
        }

        public async Task<Answers> GetAnswersById(Guid Id)
        {
            return await(from data in Context.Answers
                         where data.Id==Id
                         select data).FirstAsync();
        }
        public void CreateAnswers(Answers entity)
        {
            Add(entity);
        }

        public void DeleteAnswers(Answers entity)
        {
            throw new NotImplementedException();
        }
        public void UpdateAnswers(Answers entity)
        {
            throw new NotImplementedException();
        }
    }
}
