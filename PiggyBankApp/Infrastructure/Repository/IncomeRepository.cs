using CoderCamps.Infrastructure.Repository;
using PiggyBankApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PiggyBankApp.Infrastructure.Repository {
    public class IncomeRepository : GenericRepository<Income> {

        public IncomeRepository(DbContext db) : base(db) { }

        protected override IQueryable<Income> Include(IQueryable<Income> query) {
            return query.Include(i => i.Owner);
        }

        public IList<Income> FindByOwner(string username) {
            return (from i in Table
                    where i.Owner.UserName == username
                    select i).ToList();
        }

        public Income FindById(int id, string username) {
            return (from i in Table
                    where i.Id == id && i.Owner.UserName == username
                    select i).FirstOrDefault();
        }

        public void AddNewIncome(Income newIncome) {
            Add(newIncome);
            SaveChanges();
        }
    }
}