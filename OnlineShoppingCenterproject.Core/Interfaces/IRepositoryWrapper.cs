using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Interfaces
{
    public interface IRepositoryWrapper
    {
        public ICastomerRepository Castomer { get; }
        public ICompanyRepository Company { get; }
        public IUserRepository User { get; }
        public IaddressRepository Address { get; }
        public ICastomerAddressRepository Castomer_Address { get; }
        public IOrderRepository Order { get; }
        public IOrderItemRepository OrderItem { get; }
        public IOrderAddressRepository OrderAddress { get; }
        public IProductCompanyRepository ProductCompany { get; }
        public IFavoriteForProductRepository FavoriteForProduct { get; }
        public IProductRepository Product { get; }
        public IPaymentRepository Payment { get; }
        public IQuestionsRepository Questions { get; }
        public IAnswersRepository Answers { get; }
        public IErp Erp { get; }
        public void Save();
    }
}
