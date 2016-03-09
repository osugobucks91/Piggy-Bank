using CoderCamps.Infrastructure.Repository;
using PiggyBankApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PiggyBankApp.Infrastructure.Repository {
    public class DebtRepository : GenericRepository<Debt> {

        public DebtRepository(DbContext db) : base(db) { }

        protected override IQueryable<Debt> Include(IQueryable<Debt> query) {
            return query.Include(i => i.Owner);
        }

        public IList<Debt> FindByOwner(string username) {
            return (from i in Table
                    where i.Owner.UserName == username
                    select i).ToList();
        }

        public Debt FindById(int id, string username) {
            return (from i in Table
                    where i.Id == id && i.Owner.UserName == username
                    select i).FirstOrDefault();
        }

        public void AddNewDebt(Debt newDebt) {
            Add(newDebt);
            SaveChanges();
        }
    }
}