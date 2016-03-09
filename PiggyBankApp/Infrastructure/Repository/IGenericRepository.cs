using System.Collections.Generic;

namespace CoderCamps.Infrastructure.Repository {
    public interface IGenericRepository<T> where T : class {
        void Add(T entity);
        void Delete(params object[] keys);
        T Get(params object[] keys);
        IList<T> List();
        void SaveChanges();
    }
}