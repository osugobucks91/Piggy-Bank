using PiggyBankApp.Services;
using PiggyBankApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PiggyBankApp.Presentation.Controllers
{
    public class ExpenseController : ApiController
    {

        private SavingService _savingService;

        public ExpenseController(SavingService savingService) {
            _savingService = savingService;
        }

        //Post a new expense
        public IHttpActionResult Post(ExpenseDTO newExpense) {

            if (ModelState.IsValid) {
                newExpense.Owner = new ApplicationUserDTO() {
                    UserName = User.Identity.Name
                };
                newExpense.Goal = new SavingDTO() {
                    Id = newExpense.Goal.Id
                };
                _savingService.AddNewExpense(newExpense);
                return Ok();
            }
            else {
                return BadRequest(ModelState);
            }
        }
    }
}
