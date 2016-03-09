using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiggyBankApp.Domain.Models {
    public class Saving {

        public int Id { get; set; }

        public string Item { get; set; }

        public decimal ItemValue { get; set; }

        public IList<Expense> Expenses { get; set; }

        public ApplicationUser Owner { get; set; }
    }
}