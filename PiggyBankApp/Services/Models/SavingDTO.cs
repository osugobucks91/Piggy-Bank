using PiggyBankApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiggyBankApp.Services.Models {
    public class SavingDTO {

        public int Id { get; set; }

        public string Item { get; set; }

        public decimal ItemValue { get; set; }

        public IList<ExpenseDTO> Expenses { get; set; }

        public ApplicationUserDTO Owner { get; set; }
    }
}