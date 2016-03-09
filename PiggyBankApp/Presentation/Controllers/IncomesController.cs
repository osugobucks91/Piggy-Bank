using PiggyBankApp.Services;
using PiggyBankApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PiggyBankApp.Presentation.Controllers {
    [Authorize]
    public class IncomesController : ApiController {

        private IncomeService _incomeService;

        public IncomesController(IncomeService incomeService) {
            _incomeService = incomeService;
        }

        //List Incomes by Owner
        public IList<IncomeDTO> Get() {
            return _incomeService.List(User.Identity.Name);
        }

        //Get income by Id
        public IHttpActionResult Get(int id) {
            var income = _incomeService.FindById(id, User.Identity.Name);

            if (income != null) {
                return Ok(income);
            }
            return Unauthorized();
        }

        //Post a new income
        public IHttpActionResult Post(IncomeDTO newIncome) {

            if (ModelState.IsValid) {
                newIncome.Owner = new ApplicationUserDTO() {
                    UserName = User.Identity.Name
                };
                _incomeService.AddNewIncome(newIncome);
                return Ok();
            }
            else {
                return BadRequest(ModelState);
            }
        }

        //Delete an income
        public void Delete(int id) {
            _incomeService.DeleteIncome(id, User.Identity.Name);
        }

        //Update an income
        public IHttpActionResult Post(int id, IncomeDTO newIncome) {

            if(ModelState.IsValid) {
                newIncome.Owner = new ApplicationUserDTO() {
                    UserName = User.Identity.Name
                };
                _incomeService.EditIncome(id, newIncome, User.Identity.Name);
                return Ok();
            }
            else {
                return BadRequest(ModelState);
            }
        }
    }
}
