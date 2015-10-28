using System;
using System.Collections.Generic;

namespace UnitTestingLab
{
    class BankAccount
    {

        private string sortCode;
        private string accountNumber;
        private double overdraftLimit;
        private double balance;
        private List<double> transactionHistory;


        public string SortCode => sortCode;
        public string AccountNumber => accountNumber;
        public double OverdraftLimit => overdraftLimit;
        public double Balance => balance;

        public List<double> TransactionHistory { get; }


        public BankAccount(string sortCode, string accountNumber, double overdraftLimit)
        {
            balance = 0;
            this.sortCode = sortCode;
            this.accountNumber = accountNumber;
            this.overdraftLimit = overdraftLimit;
        }

        public BankAccount(string sortCode, string accountNumber)
        {
            balance = 0;
            overdraftLimit = 0;
            this.accountNumber = accountNumber;
            this.sortCode = sortCode;
        }


        public double Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                return Balance;
            }
            else
                throw new Exception(amount + " is an invalid amount to deposit");
        }

        public double Withdraw(double amount)
        {
            if (amount < balance && amount > 0)
            {
                balance -= amount;

                return Balance;
            }
            else
                throw new Exception(amount + "is an invalid amount to withdraw");

        }

        public override string ToString()
        {
            return "Sort Code:\t" + SortCode + "\nAccount Number\t" + accountNumber + "\nBalance:\t" + balance;
        }
    }
}
