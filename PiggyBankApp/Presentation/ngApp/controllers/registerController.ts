namespace PiggyBankApp.Controllers {

    import User = PiggyBankApp.Models.ApplicationUser;

    export class RegisterController {

        public newUser: User;

        public validationErrors;

        constructor(private $http, private $window, private $location) { }

        public register() {

            this.$http.post('/api/Account/Register', this.newUser)
                .then((response) => {
                    this.newUser = null;
                    this.$location.path('/login');
                })
                .catch((response) => {
                    this.validationErrors = [];

                    let modelState = response.data.modelState;
                    for (let error in modelState) {
                        this.validationErrors = this.validationErrors.concat(modelState[error]);
                    }
                })
        }

    }
}