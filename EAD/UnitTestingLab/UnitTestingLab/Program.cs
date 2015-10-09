using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingLab
{
    class Program
    {

        class BankAccount
        {

            private string sortCode;
            private string accountNumber;
            private double overdraftLimit;
            private double balance;
            private List<double> transactionHistory;


            public string SortCode => sortCode;
            public string AccountNumber => accountNumber;j
            public double OverdraftLimit => overdraftLimit;
            public double Balance => balance;

            public List<double> TransactionHistory { get }


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
                    throw new Exception("Invalid amount to deposit");
            }

            public double Withdraw(double amount)
            {
                if (amount < balance && amount > 0)
                {
                    balance -= amount;
                    
                    return Balance;
                }
                else
                    throw  new Exception("Invalid amount to withdraw");

            }

        }

        static void Main()
        {
        }
    }
}
