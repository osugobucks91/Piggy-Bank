var PiggyBankApp;
(function (PiggyBankApp) {
    var Controllers;
    (function (Controllers) {
        var ListController = (function () {
            function ListController($http, $location, $routeParams) {
                var _this = this;
                this.$http = $http;
                this.$location = $location;
                this.$routeParams = $routeParams;
                this.$location = $location;
                $http.get('api/incomes')
                    .then(function (response) {
                    _this.incomes = response.data;
                });
                $http.get('api/debts')
                    .then(function (response) {
                    _this.debts = response.data;
                });
                $http.get('api/savingslist')
                    .then(function (response) {
                    _this.savings = response.data;
                });
            }
            ListController.prototype.goToIncomeDetails = function (id) {
                this.$location.path("/details/income/" + id);
            };
            ListController.prototype.goToDebtDetails = function (id) {
                this.$location.path("/details/debt/" + id);
            };
            ListController.prototype.goToSavingDetails = function (id) {
                this.$location.path("/savings/" + id);
            };
            return ListController;
        })();
        Controllers.ListController = ListController;
    })(Controllers = PiggyBankApp.Controllers || (PiggyBankApp.Controllers = {}));
})(PiggyBankApp || (PiggyBankApp = {}));
//# sourceMappingURL=listController.js.map