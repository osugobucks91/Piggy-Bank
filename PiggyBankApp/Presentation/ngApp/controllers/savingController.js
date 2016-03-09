var PiggyBankApp;
(function (PiggyBankApp) {
    var Controllers;
    (function (Controllers) {
        var Saving = PiggyBankApp.Models.Saving;
        var SavingController = (function () {
            function SavingController($http, $routeParams, $location) {
                var _this = this;
                this.$http = $http;
                this.$routeParams = $routeParams;
                this.$location = $location;
                $http.get("/api/savings/" + $routeParams['id'])
                    .then(function (response) {
                    _this.savings = new Saving();
                    _this.savings.id = response.data.id;
                    _this.savings.item = response.data.item;
                    _this.savings.itemValue = response.data.itemValue;
                    _this.savings.expenses = response.data.expenses;
                    _this.savings.owner = response.data.owner;
                    _this.savings.total = response.data.total;
                });
            }
            SavingController.prototype.deleteSaving = function () {
                var _this = this;
                this.$http.delete("/api/savings/" + this.savings.id)
                    .then(function (response) {
                    _this.$location.path('/saving');
                });
            };
            SavingController.prototype.goToUpdate = function (id) {
                this.$location.path("/update/savings/" + this.savings.id);
            };
            return SavingController;
        })();
        Controllers.SavingController = SavingController;
    })(Controllers = PiggyBankApp.Controllers || (PiggyBankApp.Controllers = {}));
})(PiggyBankApp || (PiggyBankApp = {}));
//# sourceMappingURL=savingController.js.map