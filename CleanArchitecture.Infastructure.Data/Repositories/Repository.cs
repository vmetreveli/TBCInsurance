using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        public async Task<T> Add(T entity)
        {
            await DbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Delete(T entity)
        {
            DbSet.Remove(entity);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> Update(T entity)
        {
            DbSet.Attach(entity);
            var entry = _context.Entry(entity);
            return await _context.SaveChangesAsync();

        }

        public async Task<IQueryable<T>> SearchFor(Expression<Func<T, bool>> predicate) =>
            DbSet.Where(predicate);

        public async Task<IQueryable<T>> GetAll() =>
            DbSet;

        public async Task<T> GetById(int id) =>
            // Beware the == operator throws NotSupported Exception!
            // 'The Mapping of Interface Member is not supported'
            // Use .Equals() instead
            await DbSet.FindAsync(id);

        #endregion
    }
}