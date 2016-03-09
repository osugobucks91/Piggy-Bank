var PiggyBankApp;
(function (PiggyBankApp) {
    var Controllers;
    (function (Controllers) {
        var DeleteController = (function () {
            function DeleteController($http, $routeParams) {
                this.$http = $http;
                this.$routeParams = $routeParams;
            }
            DeleteController.prototype.deleteIncome = function () {
                var _this = this;
                this.$http.post("/api/incomes/" + this.income.id, this.income.id)
                    .then(function (response) {
                    _this.income = null;
                });
            };
            return DeleteController;
        })();
        Controllers.DeleteController = DeleteController;
    })(Controllers = PiggyBankApp.Controllers || (PiggyBankApp.Controllers = {}));
})(PiggyBankApp || (PiggyBankApp = {}));
