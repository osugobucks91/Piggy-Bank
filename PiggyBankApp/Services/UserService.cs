using Microsoft.AspNet.Identity.EntityFramework;
using PiggyBankApp.Domain.Models;
using PiggyBankApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PiggyBankApp.Services {
    public class UserService {

        private IncomeRepository _incomeRepo;

        private DebtRepository _debtRepo;

        private ApplicationUserManager _userManager;

        public UserService(IncomeRepository incomeRepo, DebtRepository debtRepo, DbContext context) {

            _incomeRepo = incomeRepo;

            _debtRepo = debtRepo;

            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
        }
    }
}