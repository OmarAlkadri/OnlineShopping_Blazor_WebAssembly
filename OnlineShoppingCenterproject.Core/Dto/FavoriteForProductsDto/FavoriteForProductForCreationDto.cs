﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.FavoriteForProductsDto
{
    public class FavoriteForProductForCreationDto
    {
        public Guid ProductId { get; set; }
        public Guid CastomerId { get; set; }
    }
}
