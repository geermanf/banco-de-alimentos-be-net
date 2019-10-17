using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Farmacity.FCDM.BackOffice.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Get(long id);
        Object Add(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T FindEntity(Expression<Func<T, bool>> predicate);
        T FindEntity(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        void Remove(long entity);
        IEnumerable<T> GetAllByFilters(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        T Update(T entity);

    }
}
