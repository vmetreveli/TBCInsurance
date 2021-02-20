using System;
using System.Linq;
using System.Linq.Expressions;
namespace CleanArchitecture.Domain.Interfaces
{
    public interface IRepository<T>
    {
        //  IEnumerable<Student> GetStudents();
        T Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
