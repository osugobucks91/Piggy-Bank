namespace PiggyBankApp.Controllers {

    import Income = PiggyBankApp.Models.Income;

    export class IncomeDetailsController {

        public income: Income;

        constructor(private $http, private $location, private $routeParams) {

            $http.get(`/api/incomes/${$routeParams['id']}`)
                .then((response) => {
                    this.income = response.data;
                })
        }

        public deleteIncome() { 

            this.$http.delete(`/api/incomes/${this.income.id}`)
                .then((response) => {
                    this.$location.path('/list');
                });
        }

        public goToUpdate(id: number) {
            this.$location.path(`/update/income/${this.income.id}`);
        }
    }
}