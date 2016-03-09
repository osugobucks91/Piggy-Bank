namespace PiggyBankApp.Controllers {

    import Debt = PiggyBankApp.Models.Debt;

    export class DebtDetailsController {

        public debt: Debt;

        constructor(private $http, private $location, private $routeParams) {

            $http.get(`/api/debts/${$routeParams['id']}`)
                .then((response) => {
                    this.debt = response.data;
                })
        }

        public deleteDebt() {

            this.$http.delete(`/api/debts/${this.debt.id}`)
                .then((response) => {
                    this.$location.path('/list');
                });
        }

        public goToUpdate(id: number) {
            this.$location.path(`/update/debt/${this.debt.id}`);
        }
    }
}