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
    public class SavingsController : ApiController
    {

        private SavingService _savingService;

        public SavingsController(SavingService savingService) {
            _savingService = savingService;
        }

        public SavingDTO Get() {
            return _savingService.GetSavingGoal(User.Identity.Name);
        }

        //Get saving goals by Id
        public IHttpActionResult Get(int id) {
            var saving = _savingService.FindById(id, User.Identity.Name);
            if (saving != null) {
                return Ok(saving);
            }
            return Unauthorized();
        }

        //Post a new saving
        public IHttpActionResult Post(SavingDTO newSaving) {

            if(ModelState.IsValid) {
                newSaving.Owner = new ApplicationUserDTO() {
                    UserName = User.Identity.Name
                };
                _savingService.AddNewSaving(newSaving);
                return Ok();
            }
            else {
                return BadRequest(ModelState);
            }
        }

        //Delete a saving
        public void Delete(int id) {
            _savingService.DeleteSaving(id, User.Identity.Name);
        }

        //Update a saving
        public IHttpActionResult Post(int id, SavingDTO newSaving) {

            if(ModelState.IsValid) {
                newSaving.Owner = new ApplicationUserDTO() {
                    UserName = User.Identity.Name
                };
                _savingService.EditSaving(id, newSaving, User.Identity.Name);
                return Ok();
            }
            else {
                return BadRequest(ModelState);
            }
        }
    }
}
