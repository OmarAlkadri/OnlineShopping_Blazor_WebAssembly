using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<List<Payment>> GetAllPayment();
        Task<Payment> GetPaymentById(Guid PaymentId);
        void CreatePayment(Payment entity);
        void UpdatePayment(Payment entity);
        void DeletePayment(Payment entity);
    }
}
