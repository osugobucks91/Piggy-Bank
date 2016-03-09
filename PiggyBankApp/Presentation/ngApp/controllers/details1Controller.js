var PiggyBankApp;
(function (PiggyBankApp) {
    var Controllers;
    (function (Controllers) {
        var Details1Controller = (function () {
            function Details1Controller($http, $routeParams) {
                var _this = this;
                this.$http = $http;
                this.$routeParams = $routeParams;
                $http.get("/api/" + $routeParams['type'] + "s/" + $routeParams['id'])
                    .then(function (response) {
                    _this.choice = response.data;
                });
            }
            return Details1Controller;
        })();
        Controllers.Details1Controller = Details1Controller;
    })(Controllers = PiggyBankApp.Controllers || (PiggyBankApp.Controllers = {}));
})(PiggyBankApp || (PiggyBankApp = {}));
//# sourceMappingURL=details1Controller.js.map