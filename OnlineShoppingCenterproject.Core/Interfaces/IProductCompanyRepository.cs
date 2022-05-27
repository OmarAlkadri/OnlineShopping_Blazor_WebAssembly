using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Interfaces
{
    public interface IProductCompanyRepository : IRepository<ProductCompany>
    {
        Task<List<Product>> GetAllProductCompany(string UserName);
        void CreateProduct(ProductCompany entity);
        void UpdateProduct(ProductCompany entity);
    }
}