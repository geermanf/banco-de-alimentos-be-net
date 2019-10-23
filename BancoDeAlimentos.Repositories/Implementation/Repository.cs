using BancoDeAlimentos.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BancoDeAlimentos.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DB_FCDM_BackOfficeContext _context;
        private const string PredicateEmpty = "False";

        public Repository(DB_FCDM_BackOfficeContext context)
        {
            _context = context;
        }

        public Object Add(T entity)
        {
            return _context.Set<T>().Add(entity);
        }

        public T Get(long id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(long id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T FindEntity(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T FindEntity(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (include != null)
            {
                query = include(query);
            }

            return query.FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate,Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (include != null)
            {
                query = include(query);
            }

            return query.Where(predicate);
        }

        public IEnumerable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (include != null)
            {
                query = include(query);
            }

            return query;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public IEnumerable<T> GetAllByFilters(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (include != null)
            {
                query = include(query);
            }

            if (!PredicateEmpty.Equals(predicate.Body.ToString()))
            {
                return query.Where(predicate);
            }
            return query;
        }

        public T Update(T entity)
        {
            return _context.Set<T>().Update(entity).Entity;
        }

    }
}
