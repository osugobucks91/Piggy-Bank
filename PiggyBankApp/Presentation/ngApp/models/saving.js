var PiggyBankApp;
(function (PiggyBankApp) {
    var Models;
    (function (Models) {
        var Saving = (function () {
            function Saving() {
            }
            Object.defineProperty(Saving.prototype, "total", {
                get: function () {
                    return this.expenses.reduce(function (memo, current) {
                        return memo + current.value;
                    }, 0);
                },
                enumerable: true,
                configurable: true
            });
            Object.defineProperty(Saving.prototype, "remainderToGoal", {
                get: function () {
                    return this.itemValue - this.total;
                },
                enumerable: true,
                configurable: true
            });
            return Saving;
        })();
        Models.Saving = Saving;
    })(Models = PiggyBankApp.Models || (PiggyBankApp.Models = {}));
})(PiggyBankApp || (PiggyBankApp = {}));
//# sourceMappingURL=saving.js.map