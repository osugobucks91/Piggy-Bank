using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiggyBankApp.Domain.Models {
    public class Income {

        public int Id { get; set; }

        public ApplicationUser Owner { get; set; }

        public string Type { get; set; }

        public string Frequency { get; set; }

        public decimal DollarAmount { get; set; }

        public decimal TotalMonthlyAmount { get; set; }

        public string CompanyName { get; set; }
    }
}