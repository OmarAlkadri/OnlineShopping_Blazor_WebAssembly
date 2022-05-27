using OnlineShoppingCenterproject.Core.Interfaces;
using OnlineShoppingCenterproject.Data_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Data.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private Context_DB _repoContext;
        private ICastomerRepository _Castomer;
        private ICompanyRepository _Company;
        private IUserRepository _User;
        private IaddressRepository _Address;
        private ICastomerAddressRepository _Castomer_Address;
        private IOrderRepository _Order;
        private IOrderItemRepository _OrderItem;
        private IOrderAddressRepository _Order_Address;
        private IProductCompanyRepository _ProductCompany;
        private IProductRepository _Product;
        private IPaymentRepository _Payment;
        private IFavoriteForProductRepository _FavoriteForProduct;
        private IQuestionsRepository _Questions;
        private IAnswersRepository _Answers;
        private IErp _Erp;

        public RepositoryWrapper(Context_DB repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public IErp Erp
        {
            get
            {
                if (_Erp == null)
                {
                    _Erp = new Erp(_repoContext);
                }
                return _Erp;
            }
        }
        public ICastomerRepository Castomer
        {
            get
            {
                if (_Castomer == null)
                {
                    _Castomer = new CastomerRepository(_repoContext);
                }
                return _Castomer;
            }
        }
        public IQuestionsRepository Questions
        {
            get
            {
                if (_Questions == null)
                {
                    _Questions = new QuestionsRepository(_repoContext);
                }
                return _Questions;
            }
        }        
        public IAnswersRepository Answers
        {
            get
            {
                if (_Answers == null)
                {
                    _Answers = new AnswersRepository(_repoContext);
                }
                return _Answers;
            }
        }  
        public IPaymentRepository Payment
        {
            get
            {
                if (_Payment == null)
                {
                    _Payment = new PaymentRepository(_repoContext);
                }
                return _Payment;
            }
        }
        public ICompanyRepository Company
        {
            get
            {
                if (_Company == null)
                {
                    _Company = new CompanyRepository(_repoContext);
                }
                return _Company;
            }
        }
        public IUserRepository User
        {
            get
            {
                if (_User == null)
                {
                    _User = new UserRepository(_repoContext);
                }
                return _User;
            }
        }
        public IaddressRepository Address
        {
            get
            {
                if (_Address == null)
                {
                    _Address = new AddressRepository(_repoContext);
                }
                return _Address;
            }
        }
        public ICastomerAddressRepository Castomer_Address
        {
            get
            {
                if (_Castomer_Address == null)
                {
                    _Castomer_Address = new CastomerAddressRepository(_repoContext);
                }
                return _Castomer_Address;
            }
        }
        public IOrderRepository Order
        {
            get
            {
                if (_Order == null)
                {
                    _Order = new Order_Repository(_repoContext);
                }
                return _Order;
            }
        }
        public IOrderItemRepository OrderItem
        {
            get
            {
                if (_OrderItem == null)
                {
                    _OrderItem = new OrderItemRepository(_repoContext);
                }
                return _OrderItem;
            }
        }
        public IOrderAddressRepository OrderAddress
        {
            get
            {
                if (_Order_Address == null)
                {
                    _Order_Address = new OrderAddressRepository(_repoContext);
                }
                return _Order_Address;
            }
        }
        public IProductCompanyRepository ProductCompany
        {
            get
            {
                if (_ProductCompany == null)
                {
                    _ProductCompany = new ProductCompanyRepository(_repoContext);
                }
                return _ProductCompany;
            }
        }   
        public IProductRepository Product
        {
            get
            {
                if (_Product == null)
                {
                    _Product = new ProductRepository(_repoContext);
                }
                return _Product;
            }
        }
        public IFavoriteForProductRepository FavoriteForProduct
        {
            get
            {
                if (_FavoriteForProduct == null)
                {
                    _FavoriteForProduct = new FavoriteForProductRepository(_repoContext);
                }
                return _FavoriteForProduct;
            }
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
