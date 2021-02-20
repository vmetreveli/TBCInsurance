using System;
using System.Linq;
using System.Linq.Expressions;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
namespace CleanArchitecture.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> DbSet;
        public Repository(UniDbContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }
        #region IRepository<T> Members

        public T Insert(T entity)
        {
            DbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            var entry = _context.Entry(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            // Beware the == operator throws NotSupported Exception!
            // 'The Mapping of Interface Member is not supported'
            // Use .Equals() instead
            return DbSet.Find(id);
        }

        #endregion
    }
}
