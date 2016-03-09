using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiggyBankApp.Services.Models {
    public class IncomeDTO {

        public int Id { get; set; }

        public ApplicationUserDTO Owner { get; set; }

        public string Type { get; set; }

        public string Frequency { get; set; }

        public decimal DollarAmount { get; set; }

        public decimal TotalMonthlyAmount { get; set; }

        public string CompanyName { get; set; }
    }
}