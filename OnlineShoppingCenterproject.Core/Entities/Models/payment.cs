using OnlineShoppingCenterproject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Entities
{
    public class Payment : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public double SpecialOffer { get; set; }
        public double total{ get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
