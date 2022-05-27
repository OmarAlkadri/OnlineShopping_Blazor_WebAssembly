
using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.CompanysDto
{
    public class CompanyForUpdateDto
    {
        public string? CompanyName { get; set; }
        public string? CompanyType { get; set; }
        public string? startingDate { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }

    }
}
