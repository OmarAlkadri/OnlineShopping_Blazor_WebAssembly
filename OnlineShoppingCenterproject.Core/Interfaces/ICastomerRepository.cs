using OnlineShoppingCenterproject.Core.Dto;
using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Interfaces
{
    public interface ICastomerRepository : IRepository<Castomer>
    {
        Task<IEnumerable<Castomer>> GetAllCastomer();
        Task<Castomer> GetCastomerByUserName(string userName);
        void CreateCastomer(Castomer entity);
        void UpdateCastomer(Castomer entity);
        void DeleteCastomer(Castomer entity);

    }
}
