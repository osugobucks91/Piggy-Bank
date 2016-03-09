namespace PiggyBankApp.Controllers {

    import Saving = PiggyBankApp.Models.Saving;

    export class SavingController {

        public savings: Saving;

        constructor(private $http, private $routeParams, private $location) {

            $http.get(`/api/savings/${$routeParams['id']}`)
                .then((response) => {
                    this.savings = new Saving();
                    this.savings.id = response.data.id;
                    this.savings.item = response.data.item;
                    this.savings.itemValue = response.data.itemValue;
                    this.savings.expenses = response.data.expenses;
                    this.savings.owner = response.data.owner;
                    this.savings.total = response.data.total;
                });
        }

        public deleteSaving() {

            this.$http.delete(`/api/savings/${this.savings.id}`)
                .then((response) => {
                    this.$location.path('/saving');
                });
        }

        public goToUpdate(id: number) {
            this.$location.path(`/update/savings/${this.savings.id}`);
        }
    }
}