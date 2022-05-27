using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.PaymentsDto
{
    public class PaymentForCreationDto
    {
        public double SpecialOffer { get; set; }
        public Guid OrderId { get; set; }
    }
}
