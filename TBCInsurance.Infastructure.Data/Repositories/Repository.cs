using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infastructure.Data.Repositories
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

        public async Task<T> Insert(T entity)
        {
            await DbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(T entity)
        {
            DbSet.Remove(entity);
             await _context.SaveChangesAsync();
             return true;
        }

        public async Task<bool> Update(T entity)
        {
            DbSet.Attach(entity);
            var entry = _context.Entry(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<T>> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return DbSet;
        }

        public async Task<T> GetById(int id)
        {
            // Beware the == operator throws NotSupported Exception!
            // 'The Mapping of Interface Member is not supported'
            // Use .Equals() instead
            return await DbSet.FindAsync(id);
        }

        #endregion
    }
}
