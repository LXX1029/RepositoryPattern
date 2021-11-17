using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence5Dot0.Repositories
{
    internal class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _dbContext;

        public RepositoryBase(RepositoryContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IQueryable<T> FindAll()
        {
            return this._dbContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._dbContext.Set<T>().Where(expression);
        }

        public void Insert(T t)
        {
            this._dbContext.Set<T>().Add(t);
        }

        public void Remove(T t)
        {
            this._dbContext.Set<T>().Remove(t);
        }

        public void Update(T t)
        {
            System.Diagnostics.Debug.WriteLine(this._dbContext.Entry(t).State);
            this._dbContext.Set<T>().Update(t);
        }
    }
}
