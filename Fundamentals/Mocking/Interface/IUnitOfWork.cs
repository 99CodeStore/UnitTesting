using System.Linq;

namespace Fundamentals.Mocking
{
    public interface IUnitOfWork
    {
        IQueryable<T> Query<T>();
    }
}