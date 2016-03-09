var PiggyBankApp;
(function (PiggyBankApp) {
    var Controllers;
    (function (Controllers) {
        var Saving = PiggyBankApp.Models.Saving;
        var CreateController = (function () {
            function CreateController($http, $routeParams, $location) {
                this.$http = $http;
                this.$routeParams = $routeParams;
                this.$location = $location;
            }
            CreateController.prototype.addIncome = function () {
                var _this = this;
                this.$http.post('/api/incomes', this.newIncome)
                    .then(function (response) {
                    _this.newIncome = null;
                    _this.$location.path('/list');
                })
                    .catch(function (response) {
                    _this.validationErrors = [];
                    var modelState = response.data.modelState;
                    for (var error in modelState) {
                        _this.validationErrors = _this.validationErrors.concat(modelState[error]);
                    }
                });
            };
            CreateController.prototype.addDebt = function () {
                var _this = this;
                this.$http.post('/api/debts', this.newDebt)
                    .then(function (response) {
                    _this.newDebt = null;
                    _this.$location.path('/list');
                })
                    .catch(function (response) {
                    _this.validationErrors = [];
                    var modelState = response.data.modelState;
                    for (var error in modelState) {
                        _this.validationErrors = _this.validationErrors.concat(modelState[error]);
                    }
                });
            };
            CreateController.prototype.addExpense = function () {
                var _this = this;
                this.newExpense.goal = new Saving();
                this.newExpense.goal.id = this.$routeParams.id;
                this.$http.post('/api/expense', this.newExpense)
                    .then(function (response) {
                    _this.newExpense = null;
                })
                    .catch(function (response) {
                    _this.validationErrors = [];
                    var modelState = response.data.modelState;
                    for (var error in modelState) {
                        _this.validationErrors = _this.validationErrors.concat(modelState[error]);
                    }
                });
            };
            CreateController.prototype.addSaving = function () {
                var _this = this;
                this.$http.post('/api/savings', this.newSaving)
                    .then(function (response) {
                    _this.newSaving = null;
                    _this.$location.path('/saving');
                })
                    .catch(function (response) {
                    _this.validationErrors = [];
                    var modelState = response.data.modelState;
                    for (var error in modelState) {
                        _this.validationErrors = _this.validationErrors.concat(modelState[error]);
                    }
                });
            };
            return CreateController;
        })();
        Controllers.CreateController = CreateController;
    })(Controllers = PiggyBankApp.Controllers || (PiggyBankApp.Controllers = {}));
})(PiggyBankApp || (PiggyBankApp = {}));
//# sourceMappingURL=createController.js.map