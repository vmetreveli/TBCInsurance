using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace CleanArchitecture.Domain.Interfaces
{
    public interface IRepository<T>
    {
        //  IEnumerable<Student> GetStudents();
        Task<T> Add(T entity);
        Task<int> Delete(T entity);
        Task<int> Update(T entity);
        Task<IQueryable<T>> SearchFor(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> GetAll();
        Task<T> GetById(int id);
    }
}
