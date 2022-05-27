using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.CompanysDto
{
    public class ImageModel
    {
        public IFormFile File { get; set; }
        public string Extension { get; set; }
        public string Source { get; set; }
        public Guid ProductId { get; set; }
    }
}
