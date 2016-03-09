namespace PiggyBankApp.Controllers {

    import Income = PiggyBankApp.Models.Income;

    export class UpdateIncomeController {

        public newIncome: Income;

        public validationErrors;

        constructor(private $http, private $routeParams, private $location) {

            $http.get(`/api/incomes/${$routeParams['id']}`)
                .then((response) => {
                    this.newIncome = response.data;
                });
        }

        public addIncome() {

            this.$http.post(`/api/incomes/${this.newIncome.id}`, this.newIncome)
                .then((response) => {
                    this.$location.path('/list');
                })
        }
    }
}