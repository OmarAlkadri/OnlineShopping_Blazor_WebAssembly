using OnlineShoppingCenterproject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Entities
{
    public class FavoriteForProduct : IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid CastomerId { get; set; }
        public Castomer Castomer { get; set; }
    }
}
