var PiggyBankApp;
(function (PiggyBankApp) {
    var Controllers;
    (function (Controllers) {
        var IncomeDetailsController = (function () {
            function IncomeDetailsController($http, $location, $routeParams) {
                var _this = this;
                this.$http = $http;
                this.$location = $location;
                this.$routeParams = $routeParams;
                $http.get("/api/incomes/" + $routeParams['id'])
                    .then(function (response) {
                    _this.income = response.data;
                });
            }
            IncomeDetailsController.prototype.deleteIncome = function () {
                var _this = this;
                this.$http.delete("/api/incomes/" + this.income.id)
                    .then(function (response) {
                    _this.$location.path('/list');
                });
            };
            IncomeDetailsController.prototype.goToUpdate = function (id) {
                this.$location.path("/update/income/" + this.income.id);
            };
            return IncomeDetailsController;
        })();
        Controllers.IncomeDetailsController = IncomeDetailsController;
    })(Controllers = PiggyBankApp.Controllers || (PiggyBankApp.Controllers = {}));
})(PiggyBankApp || (PiggyBankApp = {}));
//# sourceMappingURL=incomeDetailsController.js.map