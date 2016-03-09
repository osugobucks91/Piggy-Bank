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
    public class DebtService {

        private DebtRepository _repo;

        private ApplicationUserManager _user;

        public DebtService(DebtRepository repo, ApplicationUserManager user) {
            _repo = repo;
            _user = user;
        }

        private DebtDTO Map(Debt dbDebt) {
            return dbDebt != null ? new DebtDTO() {
                Id = dbDebt.Id,
                Owner = new ApplicationUserDTO() {
                    Id = dbDebt.Owner.Id,
                    UserName = dbDebt.Owner.UserName,
                    Email = dbDebt.Owner.Email
                },
                Type = dbDebt.Type,
                Frequency = dbDebt.Frequency,
                DollarAmount = dbDebt.DollarAmount,
                TotalMonthlyAmount = dbDebt.TotalMonthlyAmount,
                CompanyName = dbDebt.CompanyName
            } : null;
        }

        private Debt Map(DebtDTO dtoDebt) {
            return dtoDebt != null ? new Debt() {
                Id = dtoDebt.Id,
                Owner = _user.FindByName(dtoDebt.Owner.UserName),
                Type = dtoDebt.Type,
                Frequency = dtoDebt.Frequency,
                DollarAmount = dtoDebt.DollarAmount,
                TotalMonthlyAmount = dtoDebt.TotalMonthlyAmount,
                CompanyName = dtoDebt.CompanyName
            } : null;
        }

        //List Debts by Owner
        public IList<DebtDTO> List(string username) {
            return _repo.FindByOwner(username).Select(d => Map(d)).ToList();
        }

        //Get Debt by Id
        public DebtDTO FindById(int id, string username) {
            return Map(_repo.FindById(id, username));
        }

        //Post a new debt
        [HttpPost]
        public void AddNewDebt(DebtDTO newDebt) {
            _repo.AddNewDebt(Map(newDebt));
        }

        //Delete a debt
        public void DeleteDebt(int id, string username) {
            Debt d = _repo.FindById(id, username);

            if (d != null) {
                _repo.Delete(id);
                _repo.SaveChanges();
            }
        }

        //Update a debt
        public void EditDebt(int id, DebtDTO newDebt, string username) {
            Debt d = _repo.FindById(id, username);

            if(d != null) {
                d.CompanyName = newDebt.CompanyName;
                d.Type = newDebt.Type;
                d.Frequency = newDebt.Frequency;
                d.DollarAmount = newDebt.DollarAmount;
                d.TotalMonthlyAmount = newDebt.TotalMonthlyAmount;
                _repo.SaveChanges();
            }
        }
    }
}