using Microsoft.EntityFrameworkCore;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;
using OnlineShoppingCenterproject.Data_DB;

namespace OnlineShoppingCenterproject.Data.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(Context_DB Context) : base(Context)
        {
        }
        public async Task<List<Company>> GetAllCompany()
        {
            var b = await (from company in Context.Company
                           select new Company
                           {
                               Id = company.Id,
                               CompanyName = company.CompanyName,
                               startingDate = company.startingDate,
                               ShopLicense = company.ShopLicense,
                               activations = company.activations,
                               UserName = company.UserName,
                               CompanyType = company.CompanyType,
                               User = new User
                               {
                                   Id = company.User.Id,
                                   Name = company.User.Name,
                                   LastName = company.User.LastName,
                                   Email = company.User.Email,
                                   Gender = company.User.Gender,
                                   //      Password =  company.User.Password
                               },
                           }).ToListAsync();
            var a = 231;
            return b;
        }

        public async Task<Company> GetCompanyByUserName(string userName)
        {
            var Company = await Context.Company.FirstAsync(x => x.UserName == userName);
            return Company;
        }
        public void CreateCompany(Company entity)
        {
            Add(entity);
        }
        public void UpdateCompany(Company entity)
        {
            Update(entity);
        }
        public void DeleteCompany(Company entity)
        {
            Delete(entity);
        }
    }
}
