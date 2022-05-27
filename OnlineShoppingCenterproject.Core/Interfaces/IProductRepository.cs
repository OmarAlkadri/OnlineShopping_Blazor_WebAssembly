using OnlineShoppingCenterproject.Core.Dto.ProductCompanysDto;
using OnlineShoppingCenterproject.Core.Entities;

namespace OnlineShoppingCenterproject.Core.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductById(Guid ProductId);

        Task<List<Product>> GetAllProduct();
        Task<int> GetPageSize();
        Task<Product> GetProduct(Guid Id);
        Task<double> GetProductByPrice(Guid Id);
        Task<List<Product>> ProductsSort(string sortOrder = " ", List<Product> product = null);
        Task<List<Product>> Page(string line, string searchString,
            int pageNumber = 1, int pageSize = 16, List<Product> product = null);
        List<Product> PageSize(int pageNumber = 1, int pageSize = 16, List<Product> product = null);
        Task<List<Product>> SearchForProduct(string line, List<Product> product = null);
        void DeleteProduct(Product entity);
        void UpdateProduct(Product entity);
        Task<Product> DeleteProductByCompany(Guid productId);
        Task<List<Product>> PageForCompany(int pageNumber = 1, int pageSize = 16, List<Product> product = null);
    }
}