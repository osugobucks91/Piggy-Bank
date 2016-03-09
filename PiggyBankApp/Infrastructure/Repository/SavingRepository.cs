using CoderCamps.Infrastructure.Repository;
using PiggyBankApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PiggyBankApp.Infrastructure.Repository {
    public class SavingRepository : GenericRepository<Saving> {

        public SavingRepository(DbContext db) : base(db) { }

        protected override IQueryable<Saving> Include(IQueryable<Saving> query) {
            return query.Include(s => s.Expenses).Include(s => s.Owner);
        }

        public IList<Saving> FindByOwner(string username) {
            return (from s in Table
                    where s.Owner.UserName == username
                    select s).ToList();
        }

        public Saving FindByOwner(string username, int id) {
            return (from s in Table
                    where s.Owner.UserName == username && s.Id == id
                    select s).FirstOrDefault();
        }

        public Saving FindById(int id, string username) {
            return (from s in Table
                    where s.Id == id && s.Owner.UserName == username
                    select s).FirstOrDefault();
        }

        public Saving FindFirstByOwner(string username) {
            return (from s in Table
                    where s.Owner.UserName == username
                    select s).FirstOrDefault();
        }

        public void AddNewSaving(Saving newSaving) {
            Add(newSaving);
            SaveChanges();
        }
    }
}