using Microsoft.EntityFrameworkCore;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;
using OnlineShoppingCenterproject.Data_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Data.Repositories
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(Context_DB Context) : base(Context)
        {
        }
        public async Task<List<Payment>> GetAllPayment()
        {
            return await (from payment in Context.Payment
                          select payment).ToListAsync();
        }
        public async Task<Payment> GetPaymentById(Guid PaymentId)
        {
            return await (from payment in Context.Payment
                          where payment.Id == PaymentId
                          select payment).FirstAsync();
        }
        public void CreatePayment(Payment entity)
        {
            Add(entity);
        }
        public void DeletePayment(Payment entity)
        {
            Delete(entity);
        }
        public void UpdatePayment(Payment entity)
        {
            Update(entity);
        }
    }
}
