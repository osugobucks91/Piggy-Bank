namespace PiggyBankApp.Models {

    export class Expense {

        public id: number;

        public name: string;

        public value: number;

        public owner;

        public goal: Saving;
    }
}