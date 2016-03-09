namespace PiggyBankApp.Models {

    export class Saving {

        public id: number;

        public item: string;

        public itemValue: number;

        public expenses: Expense[];

        public owner;

        public get total() {
            return this.expenses.reduce((memo, current) => {
                return memo + current.value;
            }, 0);
        }

        public get remainderToGoal() {

            return this.itemValue - this.total;
        }
    }
}