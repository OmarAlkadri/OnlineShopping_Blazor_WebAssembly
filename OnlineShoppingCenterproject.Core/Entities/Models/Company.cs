using OnlineShoppingCenterproject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Entities
{
    public class Company : IBaseEntity
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public string startingDate { get; set; }
        public Boolean activations { get; set; }
        public string UserName { get; set; }
        public string ShopLicense { get; set; }
       // public Guid Userid { get; set; }
        public User User { get; set; }
    }
}
