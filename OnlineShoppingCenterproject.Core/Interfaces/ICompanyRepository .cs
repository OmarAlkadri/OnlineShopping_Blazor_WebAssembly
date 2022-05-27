using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<List<Company>> GetAllCompany();
        Task<Company> GetCompanyByUserName(string UserName);
        void CreateCompany(Company entity);
        void UpdateCompany(Company entity);
        void DeleteCompany(Company entity);
    }
}
