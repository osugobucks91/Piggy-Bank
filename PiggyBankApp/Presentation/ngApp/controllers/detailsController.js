var PiggyBankApp;
(function (PiggyBankApp) {
    var Controllers;
    (function (Controllers) {
        var DetailsController = (function () {
            function DetailsController($http, $location, $routeParams) {
                var _this = this;
                this.$http = $http;
                this.$location = $location;
                this.$routeParams = $routeParams;
                $http.get("/api/incomes/" + $routeParams['id'])
                    .then(function (response) {
                    _this.income = response.data;
                });
                $http.get("/api/debts/" + $routeParams['id'])
                    .then(function (response) {
                    _this.debt = response.data;
                });
            }
            DetailsController.prototype.deleteIncome = function () {
                var _this = this;
                this.$http.delete("/api/incomes/" + this.income.id)
                    .then(function (response) {
                    _this.$location.path('/list');
                });
            };
            DetailsController.prototype.deleteDebt = function () {
                var _this = this;
                this.$http.delete("/api/debts/" + this.debt.id)
                    .then(function (response) {
                    _this.$location.path('/list');
                });
            };
            return DetailsController;
        })();
        Controllers.DetailsController = DetailsController;
    })(Controllers = PiggyBankApp.Controllers || (PiggyBankApp.Controllers = {}));
})(PiggyBankApp || (PiggyBankApp = {}));
//# sourceMappingURL=detailsController.js.map