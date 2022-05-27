using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Interfaces
{
    public interface IFavoriteForProductRepository : IRepository<FavoriteForProduct>
    {
        Task<List<FavoriteForProduct>> GetAllFavoriteForProduct(string UserName);
        Task<FavoriteForProduct> GetFavoriteForProductByProductId(Guid ProductId);
        void CreateFavoriteForProduct(FavoriteForProduct entity);
        void UpdateFavoriteForProduct(FavoriteForProduct entity);
        void DeleteFavoriteForProduct(FavoriteForProduct entity);
    }
}
