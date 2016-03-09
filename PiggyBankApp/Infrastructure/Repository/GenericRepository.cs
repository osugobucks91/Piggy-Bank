using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace CoderCamps.Infrastructure.Repository {
    public class GenericRepository<T> : IGenericRepository<T> where T : class {

        private DbContext _db;

        public GenericRepository(DbContext db) {
            _db = db;
        }

        protected virtual IQueryable<T> Include(IQueryable<T> query) { return query; }

        protected IQueryable<T> Table {
            get {
                return Include(_db.Set<T>());
            }
        }

        public IList<T> List() {
            return Table.ToList();
        }

        public T Get(params object[] keys) {
            return _db.Set<T>().Find(keys);
        }

        public void Add(T entity) {
            _db.Set<T>().Add(entity);
        }

        public void Delete(params object[] keys) {
            _db.Set<T>().Remove(Get(keys));
        }

        public void SaveChanges() {
            try {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException dbError) {
                var firstError = dbError.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
                throw new ValidationException(firstError);
            }
        }
    }
}