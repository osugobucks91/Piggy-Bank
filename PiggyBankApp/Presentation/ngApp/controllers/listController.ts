namespace PiggyBankApp.Controllers {

    import Income = PiggyBankApp.Models.Income;

    import Debt = PiggyBankApp.Models.Debt;

    import Saving = PiggyBankApp.Models.Saving;

    import Expense = PiggyBankApp.Models.Expense;

    export class ListController {

        public incomes: Income[];

        public debts: Debt[];

        public savings: Saving[];

        constructor(private $http, private $location, private $routeParams) {

            this.$location = $location;

            $http.get('api/incomes')
                .then((response) => {
                    this.incomes = response.data;
                })

            $http.get('api/debts')
                .then((response) => {
                    this.debts = response.data;
                })

            $http.get('api/savingslist')
                .then((response) => {
                    this.savings = response.data;
                })
        }

        public goToIncomeDetails(id: number) {
            this.$location.path(`/details/income/${id}`);
        }

        public goToDebtDetails(id: number) {
            this.$location.path(`/details/debt/${id}`);
        }

        public goToSavingDetails(id: number) {
            this.$location.path(`/savings/${id}`);
        }
    }
}