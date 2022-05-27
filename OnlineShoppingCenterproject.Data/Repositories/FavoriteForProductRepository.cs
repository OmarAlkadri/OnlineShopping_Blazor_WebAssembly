using Microsoft.EntityFrameworkCore;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;
using OnlineShoppingCenterproject.Data_DB;

namespace OnlineShoppingCenterproject.Data.Repositories
{
    public class FavoriteForProductRepository : RepositoryBase<FavoriteForProduct>, IFavoriteForProductRepository
    {
        public FavoriteForProductRepository(Context_DB Context) : base(Context)
        {
        }
        public async Task<List<FavoriteForProduct>> GetAllFavoriteForProduct(string UserName)
        {
            return await (from favoriteForProduct in Context.FavoriteForProduct
                          join castomer in Context.Castomer on favoriteForProduct.CastomerId equals castomer.Id
                          join product in Context.Product on favoriteForProduct.ProductId equals product.Id
                          where castomer.UserName == UserName
                          select new FavoriteForProduct
                          {
                              Id = favoriteForProduct.Id,
                              Castomer = castomer,
                              Product = product
                          }).ToListAsync();
        }
        public async Task<FavoriteForProduct> GetFavoriteForProductByProductId(Guid ProductId)
        {
            var favorite = await Context.FavoriteForProduct.Where(f => f.ProductId == ProductId).FirstOrDefaultAsync();
            if (favorite==null)
            {
                return null;
            }
            return favorite;


        }
        public void CreateFavoriteForProduct(FavoriteForProduct entity)
        {
            Add(entity);
        }
        public void DeleteFavoriteForProduct(FavoriteForProduct entity)
        {
            Delete(entity);
        }
        public void UpdateFavoriteForProduct(FavoriteForProduct entity)
        {
            Update(entity);
        }
    }
}