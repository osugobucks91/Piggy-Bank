using PiggyBankApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiggyBankApp.Services.Models {
    public class ExpenseDTO {

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public ApplicationUserDTO Owner { get; set; }

        public SavingDTO Goal { get; set; }
    }
}