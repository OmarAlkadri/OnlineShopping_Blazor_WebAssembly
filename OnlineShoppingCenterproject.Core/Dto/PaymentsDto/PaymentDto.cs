using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.PaymentsDto
{
    public class PaymentDto
    {
        public Guid Id { get; set; }
        public string Date { get; set; }
        public int SpecialOffer { get; set; }
        public double total { get; set; }
        public Guid OrderId { get; set; }
    }
}
