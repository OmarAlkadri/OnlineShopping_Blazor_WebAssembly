using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Interfaces
{
  public interface IRepository<T> where T : class
    {
        int SaveChanges();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
