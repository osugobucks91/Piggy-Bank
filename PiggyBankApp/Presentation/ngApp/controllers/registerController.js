var PiggyBankApp;
(function (PiggyBankApp) {
    var Controllers;
    (function (Controllers) {
        var RegisterController = (function () {
            function RegisterController($http, $window, $location) {
                this.$http = $http;
                this.$window = $window;
                this.$location = $location;
            }
            RegisterController.prototype.register = function () {
                var _this = this;
                this.$http.post('/api/Account/Register', this.newUser)
                    .then(function (response) {
                    _this.newUser = null;
                    _this.$location.path('/login');
                })
                    .catch(function (response) {
                    _this.validationErrors = [];
                    var modelState = response.data.modelState;
                    for (var error in modelState) {
                        _this.validationErrors = _this.validationErrors.concat(modelState[error]);
                    }
                });
            };
            return RegisterController;
        })();
        Controllers.RegisterController = RegisterController;
    })(Controllers = PiggyBankApp.Controllers || (PiggyBankApp.Controllers = {}));
})(PiggyBankApp || (PiggyBankApp = {}));
//# sourceMappingURL=registerController.js.map