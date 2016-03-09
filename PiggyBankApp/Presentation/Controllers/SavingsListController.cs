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
    public class SavingsListController : ApiController
    {

        private SavingService _savingService;

        public SavingsListController(SavingService savingService) {
            _savingService = savingService;
        }

        //List Saving Goals by Owner
        public IList<SavingDTO> Get() {
            return _savingService.List(User.Identity.Name);
        }
    }
}
