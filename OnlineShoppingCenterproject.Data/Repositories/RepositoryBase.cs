using OnlineShoppingCenterproject.Core.Interfaces;
using OnlineShoppingCenterproject.Data_DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace OnlineShoppingCenterproject.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected Context_DB Context { get; set; }
        public RepositoryBase(Context_DB Context)
        {
            this.Context = Context;
        }
        public void Add(T entity) => Context.Add(entity);
        public void Delete(T entity) => Context.Remove(entity);
        public int SaveChanges() => Context.SaveChanges();
        public void Update(T entity) => Context.Update(entity);
    }
}
