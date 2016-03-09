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
    [Authorize]
    public class DebtsController : ApiController
    {

        private DebtService _debtService;

        public DebtsController(DebtService debtService) {
            _debtService = debtService;
        }

        //List Debts by Owner
        public IList<DebtDTO> Get() {
            return _debtService.List(User.Identity.Name);
        }

        //Get debt by Id
        public IHttpActionResult Get(int id) {
            var debt = _debtService.FindById(id, User.Identity.Name);

            if (debt != null) {
                return Ok(debt);
            }
            return Unauthorized();
        }

        //Post a new Debt
        public  IHttpActionResult Post(DebtDTO newDebt) {

            if(ModelState.IsValid) {
                newDebt.Owner = new ApplicationUserDTO() {
                    UserName = User.Identity.Name
                };
                _debtService.AddNewDebt(newDebt);
                return Ok();
            }
            else {
                return BadRequest(ModelState);
            } 
        }

        //Delete a debt
        public void Delete(int id) {
            _debtService.DeleteDebt(id, User.Identity.Name);
        }

        //Update a debt
        public IHttpActionResult Post(int id, DebtDTO newDebt) {

            if(ModelState.IsValid) {
                newDebt.Owner = new ApplicationUserDTO() {
                    UserName = User.Identity.Name
                };
                _debtService.EditDebt(id, newDebt, User.Identity.Name);
                return Ok();
            }
            else {
                return BadRequest(ModelState);
            }
        }
    }
}
