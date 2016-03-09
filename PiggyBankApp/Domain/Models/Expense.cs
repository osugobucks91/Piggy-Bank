using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiggyBankApp.Domain.Models {
    public class Expense {

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public ApplicationUser Owner { get; set; }

        public Saving Goal { get; set; }
    }
}