using OnlineShoppingCenterproject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Entities
{
    public class Castomer : IBaseEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public User User { get; set; }
    }
}