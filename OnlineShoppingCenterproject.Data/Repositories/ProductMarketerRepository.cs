using OnlineShoppingCenterproject.Core.Dto;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;
using OnlineShoppingCenterproject.Data_DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShoppingCenterproject.Core.Dto.ProductCompanysDto;

namespace OnlineShoppingCenterproject.Data.Repositories
{
    public class ProductCompanyRepository : RepositoryBase<ProductCompany>, IProductCompanyRepository
    {
        protected Context_DB Context { get; set; }
        public ProductCompanyRepository(Context_DB Context) : base(Context)
        {
            this.Context = Context;
        }
        public void CreateProduct(ProductCompany entity)
        {
            Add(entity);
        }
        public void UpdateProduct(ProductCompany entity)
        {
            Update(entity);
        }

        public async Task<List<Product>> GetAllProductCompany(string UserName)
        {
            var a = await (from data in Context.ProductCompany
                           join company in Context.Company on data.CompanyId equals company.Id
                           join products in Context.Product on data.ProductId equals products.Id
                           where company.UserName == UserName
                           select products).ToListAsync();
            return a;
        }
    }
}
