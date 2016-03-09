var PiggyBankApp;
(function (PiggyBankApp) {
    var Controllers;
    (function (Controllers) {
        var UpdateSavingController = (function () {
            function UpdateSavingController($http, $routeParams, $location) {
                var _this = this;
                this.$http = $http;
                this.$routeParams = $routeParams;
                this.$location = $location;
                $http.get("/api/savings/" + $routeParams['id'])
                    .then(function (response) {
                    _this.newSaving = response.data;
                });
            }
            UpdateSavingController.prototype.addSaving = function () {
                var _this = this;
                this.$http.post("/api/savings/" + this.newSaving.id, this.newSaving)
                    .then(function (response) {
                    _this.$location.path('/saving');
                });
            };
            return UpdateSavingController;
        })();
        Controllers.UpdateSavingController = UpdateSavingController;
    })(Controllers = PiggyBankApp.Controllers || (PiggyBankApp.Controllers = {}));
})(PiggyBankApp || (PiggyBankApp = {}));
//# sourceMappingURL=updateSavingController.js.map