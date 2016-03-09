using PiggyBankApp.Domain.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PiggyBankApp.Infrastructure {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) {
        }

        public static ApplicationDbContext Create() {
            return new ApplicationDbContext();
        }

        public IDbSet<Income> Incomes { get; set; }

        public IDbSet<Debt> Debts { get; set; }

        public IDbSet<Saving> Savings { get; set; }

        public IDbSet<Expense> Expenses { get; set; }
    }
}