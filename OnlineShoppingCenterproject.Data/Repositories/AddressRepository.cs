using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;
using OnlineShoppingCenterproject.Data_DB;

namespace OnlineShoppingCenterproject.Data.Repositories
{
    public class AddressRepository : RepositoryBase<Address>, IaddressRepository
    {
        public AddressRepository(Context_DB Context): base(Context)
        {

        }
        public void UpdateAddress(Address entity)
        {
            Update(entity);
        }
        public void DeleteAddress(Address entity)
        {
            Delete(entity);
        }
    }
}
