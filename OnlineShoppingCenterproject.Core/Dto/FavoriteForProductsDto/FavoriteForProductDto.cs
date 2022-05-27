using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.FavoriteForProductsDto
{
    public class FavoriteForProductDto
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CastomerId { get; set; }
        public Castomer Castomer { get; set; }
    }
}
