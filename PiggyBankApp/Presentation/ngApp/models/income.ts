﻿namespace PiggyBankApp.Models {

    export class Income {

        public id: number;

        public owner;

        public type: string;

        public frequency: string;

        public dollarAmount: number;

        public totalMonthlyAmount: number;

        public companyName: string;
    }
}