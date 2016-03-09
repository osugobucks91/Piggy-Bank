var PiggyBankApp;
(function (PiggyBankApp) {
    var Controllers;
    (function (Controllers) {
        var DebtDetailsController = (function () {
            function DebtDetailsController($http, $location, $routeParams) {
                var _this = this;
                this.$http = $http;
                this.$location = $location;
                this.$routeParams = $routeParams;
                $http.get("/api/debts/" + $routeParams['id'])
                    .then(function (response) {
                    _this.debt = response.data;
                });
            }
            DebtDetailsController.prototype.deleteDebt = function () {
                var _this = this;
                this.$http.delete("/api/debts/" + this.debt.id)
                    .then(function (response) {
                    _this.$location.path('/list');
                });
            };
            DebtDetailsController.prototype.goToUpdate = function (id) {
                this.$location.path("/update/debt/" + this.debt.id);
            };
            return DebtDetailsController;
        })();
        Controllers.DebtDetailsController = DebtDetailsController;
    })(Controllers = PiggyBankApp.Controllers || (PiggyBankApp.Controllers = {}));
})(PiggyBankApp || (PiggyBankApp = {}));
//# sourceMappingURL=debtDetailsController.js.map