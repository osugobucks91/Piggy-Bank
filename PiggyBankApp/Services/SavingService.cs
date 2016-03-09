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
    public class SavingService {

        private SavingRepository _repo;

        private ExpenseRepository _Exprepo;

        private ApplicationUserManager _user;

        public SavingService(SavingRepository repo, ExpenseRepository Exprepo, ApplicationUserManager user) {
            _repo = repo;
            _Exprepo = Exprepo;
            _user = user;
        }

        private SavingDTO Map(Saving dbSaving) {
            return dbSaving != null ? new SavingDTO() {
                Id = dbSaving.Id,
                Item = dbSaving.Item,
                ItemValue = dbSaving.ItemValue,
                Expenses = (from e in dbSaving.Expenses
                            select new ExpenseDTO() {
                                Id = e.Id,
                                Name = e.Name,
                                Value = e.Value
                            }).ToList(),
                Owner = new ApplicationUserDTO() {
                    Id = dbSaving.Owner.Id,
                    UserName = dbSaving.Owner.UserName,
                    Email = dbSaving.Owner.Email
                }
            } : null;
        }

        private Saving Map(SavingDTO dtoSaving) {
            return dtoSaving != null ? new Saving() {
                Id = dtoSaving.Id,
                Item = dtoSaving.Item,
                ItemValue = dtoSaving.ItemValue,
                Owner = _user.FindByName(dtoSaving.Owner.UserName),
                //Expenses = (from e in dtoSaving.Expenses
                //            select new Expense() {
                //                Id = e.Id,
                //                Name = e.Name,
                //                Value = e.Value
                //            }).ToList()
            } : null;
        }

        private Expense Map(ExpenseDTO dtoExpense) {
            return dtoExpense != null ? new Expense() {
                Id = dtoExpense.Id,
                Owner = _user.FindByName(dtoExpense.Owner.UserName),
                Name = dtoExpense.Name,
                Value = dtoExpense.Value,
                Goal = _repo.FindByOwner(dtoExpense.Owner.UserName, dtoExpense.Goal.Id)
            } : null;
        }

        //List Savings Goals
        public IList<SavingDTO> List(string username) {
            return _repo.FindByOwner(username).Select(s => Map(s)).ToList();
        }

        //Get Savings Goal by Id
        public SavingDTO FindById(int id, string username) {
            return Map(_repo.FindById(id, username));
        }

        //List Savings Goal and Expenses
        public SavingDTO GetSavingGoal(string username) {
            return _repo.FindByOwner(username).Select(s => Map(s)).FirstOrDefault();
        }

        //Post a new Expense
        [HttpPost]
        public void AddNewExpense(ExpenseDTO newExpense) {
            _Exprepo.AddNewExpense(Map(newExpense));
        }

        //Post a new Saving
        [HttpPost]
        public void AddNewSaving(SavingDTO newSaving) {
            _repo.AddNewSaving(Map(newSaving));
        }

        //Delete a Saving
        public void DeleteSaving(int id, string username) {
            Saving s = _repo.FindById(id, username);

            if(s != null) {
                    _repo.Delete(id);
                    _repo.SaveChanges();
                }
        }

        //Update a Saving
        public void EditSaving(int id, SavingDTO newSaving, string username) {
            Saving s = _repo.FindById(id, username);

            if(s != null) {
                s.Item = newSaving.Item;
                s.ItemValue = newSaving.ItemValue;
                _repo.SaveChanges();
            }
        }
    }
}