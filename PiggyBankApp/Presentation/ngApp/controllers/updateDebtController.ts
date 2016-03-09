namespace PiggyBankApp.Controllers {

    import Debt = PiggyBankApp.Models.Debt;

    export class UpdateDebtController {

        public newDebt: Debt;

        public validationErrors;

        constructor(private $http, private $routeParams, private $location) {

            $http.get(`/api/debts/${$routeParams['id']}`)
                .then((response) => {
                    this.newDebt = response.data;
                });
        }

        public addDebt() {

            this.$http.post(`/api/debts/${this.newDebt.id}`, this.newDebt)
                .then((response) => {
                    this.$location.path('/list');
                })
        }
    }
}