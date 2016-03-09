var PiggyBankApp;
(function (PiggyBankApp) {
    angular.module("PiggyBankApp", ['ngRoute']);
    angular.module('PiggyBankApp').factory('authInterceptor', function ($q, $window, $location) {
        return {
            request: function (config) {
                config.headers = config.headers || {};
                var token = $window.localStorage.getItem('token');
                if (token) {
                    config.headers.Authorization = "Bearer " + token;
                }
                return config;
            },
            responseError: function (response) {
                if (response.status === 401) {
                    $location.path('/login');
                }
                return response || $q.when(response);
            }
        };
    });
    angular.module("PiggyBankApp")
        .config(function ($routeProvider, $httpProvider) {
        $routeProvider
            .when('/', {
            templateUrl: '/Presentation/ngApp/views/home.html'
        })
            .when('/about', {
            templateUrl: '/Presentation/ngApp/views/about.html'
        })
            .when('/contact', {
            templateUrl: '/Presentation/ngApp/views/contact.html'
        })
            .when('/list', {
            templateUrl: '/Presentation/ngApp/views/list.html',
            controller: PiggyBankApp.Controllers.ListController,
            controllerAs: 'list'
        })
            .when('/details/income/:id', {
            templateUrl: '/Presentation/ngApp/views/incomeDetails.html',
            controller: PiggyBankApp.Controllers.IncomeDetailsController,
            controllerAs: 'incDetails'
        })
            .when('/details/debt/:id', {
            templateUrl: '/Presentation/ngApp/views/debtDetails.html',
            controller: PiggyBankApp.Controllers.DebtDetailsController,
            controllerAs: 'debtDetails'
        })
            .when('/create/income', {
            templateUrl: '/Presentation/ngApp/views/createIncome.html',
            controller: PiggyBankApp.Controllers.CreateController,
            controllerAs: 'create'
        })
            .when('/create/debt', {
            templateUrl: '/Presentation/ngApp/views/createDebt.html',
            controller: PiggyBankApp.Controllers.CreateController,
            controllerAs: 'create'
        })
            .when('/create/saving', {
            templateUrl: '/Presentation/ngApp/views/createSaving.html',
            controller: PiggyBankApp.Controllers.CreateController,
            controllerAs: 'create'
        })
            .when('/create/expense/:id', {
            templateUrl: '/Presentation/ngApp/views/createExpense.html',
            controller: PiggyBankApp.Controllers.CreateController,
            controllerAs: 'create'
        })
            .when('/login', {
            templateUrl: '/Presentation/ngApp/views/login.html',
            controller: PiggyBankApp.Controllers.LoginController,
            controllerAs: 'login'
        })
            .when('/register', {
            templateUrl: '/Presentation/ngApp/views/register.html',
            controller: PiggyBankApp.Controllers.RegisterController,
            controllerAs: 'register'
        })
            .when('/saving', {
            templateUrl: '/Presentation/ngApp/views/savingList.html',
            controller: PiggyBankApp.Controllers.ListController,
            controllerAs: 'list'
        })
            .when('/savings/:id', {
            templateUrl: '/Presentation/ngApp/views/saving.html',
            controller: PiggyBankApp.Controllers.SavingController,
            controllerAs: 'sc'
        })
            .when('/update/income/:id', {
            templateUrl: '/Presentation/ngApp/views/createIncome.html',
            controller: PiggyBankApp.Controllers.UpdateIncomeController,
            controllerAs: 'create'
        })
            .when('/update/debt/:id', {
            templateUrl: '/Presentation/ngApp/views/createDebt.html',
            controller: PiggyBankApp.Controllers.UpdateDebtController,
            controllerAs: 'create'
        })
            .when('/update/savings/:id', {
            templateUrl: '/Presentation/ngApp/views/createSaving.html',
            controller: PiggyBankApp.Controllers.UpdateSavingController,
            controllerAs: 'create'
        });
        $httpProvider.interceptors.push('authInterceptor');
    });
})(PiggyBankApp || (PiggyBankApp = {}));
//# sourceMappingURL=app.js.map