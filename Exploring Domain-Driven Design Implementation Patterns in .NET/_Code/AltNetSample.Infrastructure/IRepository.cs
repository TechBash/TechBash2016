using System.Linq;
using Linq.Specifications;
using Proteus.Domain.Foundation;

namespace AltNetSample.Infrastructure
{
    public interface IRepository<T> where T : IdentityPersistenceBase<T, int>
    {
        void Save(T instance);
        void Delete(T instance);
        TResult FindOne<TResult>(ISpecification<T, TResult> specification);
        IQueryable<TResult> FindAll<TResult>(ISpecification<T, TResult> specification);
        IQueryable<T> FindAll();
        void Clear();
    }
}
