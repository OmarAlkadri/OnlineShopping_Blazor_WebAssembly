using Microsoft.EntityFrameworkCore;
using OnlineShoppingCenterproject.Core.Dto;
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
    public class Erp : IErp
    {
        private Context_DB Context;
        public Erp(Context_DB Context)
        {
            this.Context = Context;
        }

        public async Task<long> BestSellerForYear(string Year)
        {
            long product = await (from products in Context.Product
                                  join orderItem in Context.OrderItem on products.Id equals orderItem.ProductId
                                  join order in Context.Order on orderItem.OrderId equals order.Id
                                  where order.OrderDate.Year.ToString() == Year
                                  select products.Quantity).SumAsync();
            return product;
        }

        public async Task<long> BestSellerForYearForCompany(string UserName, string Year)
        {
            long product = await(from products in Context.Product
                                 join orderItem in Context.OrderItem on products.Id equals orderItem.ProductId
                                 join order in Context.Order on orderItem.OrderId equals order.Id
                                 join productCompany in Context.ProductCompany on products.Id equals productCompany.ProductId
                                 join company in Context.Company on productCompany.CompanyId equals company.Id
                                 where order.OrderDate.Year.ToString() == Year && company.UserName == UserName
                                 select products.Quantity).SumAsync();
            return product;
        }

        public async Task<CompanyForERP> GetCompanyForERP(Guid Id)
        {
            //   SoldOutProduct
            var product = await (from products in Context.Product
                                 join orderItem in Context.OrderItem on products.Id equals orderItem.ProductId
                                 join company in Context.ProductCompany on products.Id equals company.ProductId
                                 where company.CompanyId == Id
                                 select new CompanyForERP
                                 {
                                     SoldOutPrice = orderItem.Price,
                                     ExistingQuantity = products.Quantity,
                                     SoldOutQuantity = orderItem.Quantity,
                                 }).ToListAsync();

            CompanyForERP companyForERP = new CompanyForERP();
            companyForERP.SoldOutPrice = product.Sum(x => x.SoldOutPrice);
            companyForERP.ExistingQuantity = product.Sum(x => x.ExistingQuantity);
            companyForERP.SoldOutQuantity = product.Sum(x => x.SoldOutQuantity);


            return companyForERP;
        }

        public async Task<long> QuantityOfProductSold(string UserName)
        {
            long product = await(from products in Context.Product
                                 join orderItem in Context.OrderItem on products.Id equals orderItem.ProductId
                                 join order in Context.Order on orderItem.OrderId equals order.Id
                                 join productCompany in Context.ProductCompany on products.Id equals productCompany.ProductId
                                 join company in Context.Company on productCompany.CompanyId equals company.Id
                                 where company.UserName == UserName
                                 select products.Quantity).SumAsync();
            return product;
        }

        public async Task<long> QuantityForAllProduct()
        {
            long p = await Context.Product.Select(t => t.Quantity).SumAsync();

            return p;
        }

        public async Task<long> QuantityForAllProductForCompany(string UserName)
        {
            long product = await(from products in Context.Product
                                join productCompany in Context.ProductCompany on products.Id equals productCompany.ProductId
                                join company in Context.Company on productCompany.CompanyId equals company.Id
                                where company.UserName == UserName
                                select products.Quantity).SumAsync();
            return product;
        }
    }
}
