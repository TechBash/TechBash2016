using System.Collections.Generic;
using AltNetSample.Domain;
using System;
using Linq.Specifications;
using System.Linq;
using Proteus.Domain.Foundation;

namespace AltNetSample.Infrastructure
{
    public class MemoryRepository<T> : IRepository<T> where T : IdentityPersistenceBase<T, int>
    {
        protected readonly List<T> _items = new List<T>();

        #region IRepository<T> Members

        public void Save(T instance)
        {
            if (_items.Contains(instance))
            {
                _items.Remove(instance);
            }

            _items.Add(instance);
        }

        public void Delete(T instance)
        {
            if (_items.Contains(instance))
                _items.Remove(instance);
        }

        public TResult FindOne<TResult>(ISpecification<T, TResult> specification)
        {
            return FindAll(specification).SingleOrDefault();
        }

        public IQueryable<TResult> FindAll<TResult>(ISpecification<T, TResult> specification)
        {
            return specification.SatisfyingElementsFrom(_items.AsQueryable());
        }

        public IQueryable<T> FindAll()
        {
            return _items.AsQueryable();
        }

        public void Clear()
        {
            _items.Clear();
        }

        #endregion
    }
}
