namespace PiggyBankApp.Controllers {

    import Income = PiggyBankApp.Models.Income;

    import Debt = PiggyBankApp.Models.Debt;

    import Expense = PiggyBankApp.Models.Expense;

    import Saving = PiggyBankApp.Models.Saving;

    export class CreateController {

        public newIncome: Income;

        public newDebt: Debt;

        public newExpense: Expense;

        public newSaving: Saving;

        public validationErrors;

        constructor(private $http, private $routeParams, private $location) {
        }

        public addIncome() {

            this.$http.post('/api/incomes', this.newIncome)
                .then((response) => {
                    this.newIncome = null;
                    this.$location.path('/list');
                })
                .catch((response) => {
                    this.validationErrors = [];

                    let modelState = response.data.modelState;
                    for (let error in modelState) {
                        this.validationErrors = this.validationErrors.concat(modelState[error]);
                    }
                })
        }

        public addDebt() {

            this.$http.post('/api/debts', this.newDebt)
                .then((response) => {
                    this.newDebt = null;
                    this.$location.path('/list');
                })
                .catch((response) => {
                    this.validationErrors = [];

                    let modelState = response.data.modelState;
                    for (let error in modelState) {
                        this.validationErrors = this.validationErrors.concat(modelState[error]);
                    }
                })
        }

        public addExpense() {

            this.newExpense.goal = new Saving();
            this.newExpense.goal.id = this.$routeParams.id;
            this.$http.post('/api/expense', this.newExpense)
                .then((response) => {
                    this.newExpense = null;
                })
                .catch((response) => {
                    this.validationErrors = [];

                    let modelState = response.data.modelState;
                    for (let error in modelState) {
                        this.validationErrors = this.validationErrors.concat(modelState[error]);
                    }
                })
        }

        public addSaving() {

            this.$http.post('/api/savings', this.newSaving)
                .then((response) => {
                    this.newSaving = null;
                    this.$location.path('/saving');
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