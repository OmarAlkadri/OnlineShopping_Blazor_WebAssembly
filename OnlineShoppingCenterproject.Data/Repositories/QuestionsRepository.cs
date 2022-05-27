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
    public class QuestionsRepository : RepositoryBase<Questions>, IQuestionsRepository
    {
        public QuestionsRepository(Context_DB Context) : base(Context)
        {
        }
        public async Task<List<Questions>> GetAllQuestionsForCompany(Guid CompanyId)
        {
            return await (from data in Context.Questions
                          join Company in Context.ProductCompany on data.ProductId equals Company.ProductId
                          where Company.CompanyId == CompanyId
                          select new Questions
                          {
                              Id = data.Id,
                              Question = data.Question,
                              CastomerId = data.CastomerId,
                              ProductId = data.ProductId,
                          }).ToListAsync();
        }
        public async Task<List<Questions>> GetAllQuestionsForProduct(Guid ProductId)
        {
            return await (from data in Context.Questions
                          join Company in Context.ProductCompany on data.ProductId equals Company.ProductId
                          where data.ProductId == ProductId
                          select new Questions
                          {
                              Id = data.Id,
                              Question = data.Question,
                              CastomerId = data.CastomerId,
                              ProductId = data.ProductId,
                          }).ToListAsync();
        }
        public async Task<Questions> GetQuestionsById(Guid QuestionId)
        {
            return await (from data in Context.Questions
                          where data.Id == QuestionId
                          select new Questions
                          {
                              Id = data.Id,
                              Question = data.Question,
                              CastomerId = data.CastomerId,
                              ProductId = data.ProductId,
                          }).FirstAsync();
        }
        public void CreateQuestions(Questions entity)
        {
            Add(entity);
        }

        public void UpdateQuestions(Questions entity)
        {
            throw new NotImplementedException();
        }
        public void DeleteQuestions(Questions entity)
        {
            throw new NotImplementedException();
        }
    }
}
