using Microsoft.EntityFrameworkCore;
using OnlineShoppingCenterproject.Core.Dto.ProductCompanysDto;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;
using OnlineShoppingCenterproject.Data_DB;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(Context_DB Context) : base(Context)
        {

        }
        public async Task<Product> GetProductById(Guid ProductId)
        {
            var a = await (from data in Context.Product
                           where data.Id == ProductId
                           select data).FirstAsync();
            return a;
        }
        public async Task<int> GetPageSize()
        {
            double pa = await Context.Product.CountAsync();
            double p = (double)await Context.Product.CountAsync() / 16;
            if (p > (int)p)
            {
                return (int)p + 1;
            }
            return (int)p;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            var product = await (from data in Context.Product
                                 select new Product
                                 {
                                     Id = data.Id,
                                     Name = data.Name,
                                     CompanyName = data.CompanyName,
                                     WarrantyCompany = data.WarrantyCompany,
                                     ModelNumber = data.ModelNumber,
                                     Quantity = data.Quantity,
                                     Type = data.Type,
                                     Title = data.Title,
                                     Foto = data.Foto,
                                     UnitPrice = data.UnitPrice,
                                 }).ToListAsync();
            return product;
        }
        public async Task<List<Product>> ProductsSort(string sortOrder = " ", List<Product> product = null)
        {
            if (product == null)
                product = await GetAllProduct();
            switch (sortOrder)
            {
                case "increasing":
                    product = product.OrderByDescending(s => s.UnitPrice).ToList();
                    break;
                case "down":
                    product = product.OrderBy(s => s.UnitPrice).ToList();
                    break;
                default:
                    product = product.OrderBy(s => s.Name).ToList();
                    break;
            }
            return product;
        }

        public async Task<List<Product>> Page(string? sortOrder, string? searchString,
            int pageNumber = 1, int pageSize = 16, List<Product> product = null)
        {
            product = await SearchForProduct(searchString, product);
            product = await ProductsSort(sortOrder, product);
            product = PageSize(pageNumber, pageSize, product);
            return product;
        }
        public async Task<List<Product>> SearchForProduct(string line, List<Product> product = null)
        {
            if (line != null && line != " ")
            {
                string[] SearchList = line.Split(" ");
                List<Product> products = new List<Product>();
                foreach (string s in SearchList)
                {
                    product = await (from data in Context.Product
                                     where EF.Functions.Like(data.Name + " "
                                     + data.CompanyName + " " + data.ModelNumber
                                     + " " + data.Type, $"%{s}%")
                                     select new Product
                                     {
                                         Id = data.Id,
                                         Name = data.Name,
                                         Title = data.Title,
                                         Quantity = data.Quantity,
                                         Foto = data.Foto,
                                         UnitPrice = data.UnitPrice,
                                     })/*.Skip(page-1).Take(pageSize)*/.ToListAsync();
                    foreach (var item in product)
                    {
                        products.Add(item);
                    }
                }
                return products;
            }
            return null;
        }
        public List<Product> PageSize(int pageNumber = 1, int pageSize = 16, List<Product> product = null)
        {
            if (product != null)
                return product.ToPagedList(pageNumber, pageSize).ToList();
            else
                return null;
        }
        public async Task<Product> GetProduct(Guid Id)
        {
            var product = await (from data in Context.Product
                                 where data.Id == Id
                                 select data).FirstOrDefaultAsync();
            return product;
        }
        public async Task<double> GetProductByPrice(Guid Id)
        {
            var product = await (from data in Context.Product
                                 where data.Id == Id
                                 select data.UnitPrice).FirstAsync();
            return product;
        }
        public void DeleteProduct(Product entity)
        {
            Delete(entity);
        }
        public async Task<Product> DeleteProductByCompany(Guid productId)
        {
            return await (from productCompany in Context.ProductCompany
                          where productCompany.Product.Id == productId
                          select productCompany.Product).FirstAsync();
        }
        public void UpdateProduct(Product entity)
        {
            Update(entity);
        }
        public async Task<List<Product>> PageForCompany(int pageNumber = 1, int pageSize = 16, List<Product> product = null)
        {
            if (product == null)
                product = await GetAllProduct();
            product = PageSize(pageNumber, pageSize, product);
            return product;
        }
    }
}
