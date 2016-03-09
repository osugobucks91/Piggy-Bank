using Microsoft.AspNet.Identity;
using PiggyBankApp.Domain.Models;
using PiggyBankApp.Infrastructure.Repository;
using PiggyBankApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PiggyBankApp.Services {
    public class IncomeService {

        private IncomeRepository _repo;

        private ApplicationUserManager _user;

        public IncomeService(IncomeRepository repo, ApplicationUserManager user) {
            _repo = repo;
            _user = user;
        }

        private IncomeDTO Map(Income dbIncome) {
            return dbIncome != null ? new IncomeDTO() {
                Id = dbIncome.Id,
                Owner = new ApplicationUserDTO() {
                    Id = dbIncome.Owner.Id,
                    UserName = dbIncome.Owner.UserName,
                    Email = dbIncome.Owner.Email
                },
                Type = dbIncome.Type,
                Frequency = dbIncome.Frequency,
                DollarAmount = dbIncome.DollarAmount,
                TotalMonthlyAmount = dbIncome.TotalMonthlyAmount,
                CompanyName = dbIncome.CompanyName
            } : null;
        }

        private Income Map(IncomeDTO dtoIncome) {
            return dtoIncome != null ? new Income() {
                Id = dtoIncome.Id,
                Owner = _user.FindByName(dtoIncome.Owner.UserName),
                Type = dtoIncome.Type,
                Frequency = dtoIncome.Frequency,
                DollarAmount = dtoIncome.DollarAmount,
                TotalMonthlyAmount = dtoIncome.TotalMonthlyAmount,
                CompanyName = dtoIncome.CompanyName
            } : null;
        }

        //List Incomes by Owner
        public IList<IncomeDTO> List(string username) {
            return _repo.FindByOwner(username).Select(i => Map(i)).ToList();
        }

        //Get Income by Id
        public IncomeDTO FindById(int id, string username) {
            return Map(_repo.FindById(id, username));
        }

        //Post a new Income
        [HttpPost]
        public void AddNewIncome(IncomeDTO newIncome) {
            _repo.AddNewIncome(Map(newIncome));
        }

        //Delete an income
        public void DeleteIncome(int id, string username) {
            Income i = _repo.FindById(id, username);

            if (i != null) {
                _repo.Delete(id);
                _repo.SaveChanges();
            }
        }

        //Update an income
        public void EditIncome(int id, IncomeDTO newIncome, string username) {
            Income i = _repo.FindById(id, username);

            if(i != null) {
                i.CompanyName = newIncome.CompanyName;
                i.Type = newIncome.Type;
                i.Frequency = newIncome.Frequency;
                i.DollarAmount = newIncome.DollarAmount;
                i.TotalMonthlyAmount = newIncome.TotalMonthlyAmount;
                _repo.SaveChanges();
            }
        }
    }
}
