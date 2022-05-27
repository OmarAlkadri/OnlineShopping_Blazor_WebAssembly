using OnlineShoppingCenterproject.Core.Dto.UsersDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.CastomersDto
{
    public class CastomerForUpdateDto
    {
        public string? Name { get; set; } 
        public string? LastName { get; set; }
        public string? Password { get; set; } 
    }
}
