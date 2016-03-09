using CoderCamps.Infrastructure.Repository;
using PiggyBankApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PiggyBankApp.Infrastructure.Repository {
    public class ExpenseRepository : GenericRepository<Expense> {

        public ExpenseRepository(DbContext db) : base(db) { }

        protected override IQueryable<Expense> Include(IQueryable<Expense> query) {
            return query.Include(e => e.Owner).Include(e => e.Goal);
        }

        public void AddNewExpense(Expense newExpense) {
            Add(newExpense);
            SaveChanges();
        }
    }
}