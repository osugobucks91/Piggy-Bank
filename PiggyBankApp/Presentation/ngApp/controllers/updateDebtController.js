var PiggyBankApp;
(function (PiggyBankApp) {
    var Controllers;
    (function (Controllers) {
        var UpdateDebtController = (function () {
            function UpdateDebtController($http, $routeParams, $location) {
                var _this = this;
                this.$http = $http;
                this.$routeParams = $routeParams;
                this.$location = $location;
                $http.get("/api/debts/" + $routeParams['id'])
                    .then(function (response) {
                    _this.newDebt = response.data;
                });
            }
            UpdateDebtController.prototype.addDebt = function () {
                var _this = this;
                this.$http.post("/api/debts/" + this.newDebt.id, this.newDebt)
                    .then(function (response) {
                    _this.$location.path('/list');
                });
            };
            return UpdateDebtController;
        })();
        Controllers.UpdateDebtController = UpdateDebtController;
    })(Controllers = PiggyBankApp.Controllers || (PiggyBankApp.Controllers = {}));
})(PiggyBankApp || (PiggyBankApp = {}));
//# sourceMappingURL=updateDebtController.js.map