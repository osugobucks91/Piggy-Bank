var PiggyBankApp;
(function (PiggyBankApp) {
    var Controllers;
    (function (Controllers) {
        var UpdateIncomeController = (function () {
            function UpdateIncomeController($http, $routeParams, $location) {
                var _this = this;
                this.$http = $http;
                this.$routeParams = $routeParams;
                this.$location = $location;
                $http.get("/api/incomes/" + $routeParams['id'])
                    .then(function (response) {
                    _this.newIncome = response.data;
                });
            }
            UpdateIncomeController.prototype.addIncome = function () {
                var _this = this;
                this.$http.post("/api/incomes/" + this.newIncome.id, this.newIncome)
                    .then(function (response) {
                    _this.$location.path('/list');
                });
            };
            return UpdateIncomeController;
        })();
        Controllers.UpdateIncomeController = UpdateIncomeController;
    })(Controllers = PiggyBankApp.Controllers || (PiggyBankApp.Controllers = {}));
})(PiggyBankApp || (PiggyBankApp = {}));
//# sourceMappingURL=updateIncomeController.js.map