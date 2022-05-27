
using OnlineShoppingCenterproject.Core.Dto.UsersDto;
using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.CompanysDto
{
    public class CompanyDto
    {
        public CompanyDto() 
        {
            delete = false;
            IsClick = false;
        }
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public string startingDate { get; set; }
        public string ShopLicense { get; set; }
        public string UserName { get; set; }
        public Boolean activations { get; set; }
        public Boolean delete { get; set; }
        public Boolean IsClick { get; set; }
        public UserDto User { get; set; }
    }
}
