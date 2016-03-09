namespace PiggyBankApp.Controllers {

    import Saving = PiggyBankApp.Models.Saving;

    export class UpdateSavingController {

        public newSaving: Saving;

        public validationErrors;

        constructor(private $http, private $routeParams, private $location) {

            $http.get(`/api/savings/${$routeParams['id']}`)
                .then((response) => {
                    this.newSaving = response.data;
                });
        }

        public addSaving() {

            this.$http.post(`/api/savings/${this.newSaving.id}`, this.newSaving)
                .then((response) => {
                    this.$location.path('/saving');
                })
        }
    }
}