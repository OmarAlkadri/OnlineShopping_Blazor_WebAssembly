using OnlineShoppingCenterproject.Core.Dto;
using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Interfaces
{
    public interface IErp
    {
        public Task<long> QuantityForAllProduct();
        public Task<long> QuantityOfProductSold(string UserName);
        public Task<long> QuantityForAllProductForCompany(string UserName);
        public Task<long> BestSellerForYearForCompany(string UserName,string Year);
        public Task<long> BestSellerForYear(string Year);
        public Task<CompanyForERP> GetCompanyForERP(Guid Id);
    }
}
