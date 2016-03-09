var PiggyBankApp;
(function (PiggyBankApp) {
    var Services;
    (function (Services) {
        var LoginService = (function () {
            function LoginService($window) {
                this.$window = $window;
            }
            Object.defineProperty(LoginService.prototype, "username", {
                get: function () {
                    return this.$window.localStorage.getItem('username');
                },
                set: function (value) {
                    this.$window.localStorage.setItem('username', value);
                },
                enumerable: true,
                configurable: true
            });
            return LoginService;
        })();
        Services.LoginService = LoginService;
        angular.module("PiggyBankApp").service("login", LoginService);
    })(Services = PiggyBankApp.Services || (PiggyBankApp.Services = {}));
})(PiggyBankApp || (PiggyBankApp = {}));
