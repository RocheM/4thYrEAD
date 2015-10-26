using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingLab
{
    public class BankAccount
    {

        private string sortCode;
        private string accountNumber;
        private double overdraftLimit;
        private double balance;
        private List<double> transactionHistory;


        public string SortCode { get { return sortCode; } }

        public string AccountNumber { get { return accountNumber; } }

        public double OverdraftLimit { get { return overdraftLimit; } }
        public double Balance { get { return balance; } }
        public List<double> TransactionHistory { get { return transactionHistory; } }

        public BankAccount(string sortCode, string accountNumber, double overdraftLimit)
        {
            if (overdraftLimit > 0)
            {

                balance = 0;
                this.sortCode = sortCode;
                this.accountNumber = accountNumber;
                this.overdraftLimit = overdraftLimit;
                transactionHistory = new List<double>();
            }
            else
                throw new ArgumentException("Invalid Overdraft limit");
        }

        public BankAccount(string sortCode, string accountNumber)
        {
            balance = 0;
            overdraftLimit = 0;
            this.accountNumber = accountNumber;
            this.sortCode = sortCode;
            transactionHistory = new List<double>();

        }


        public double Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                transactionHistory.Add(amount);
                return Balance;
            }
            else
                throw new ArgumentException("Invalid amount to deposit");
        }

        public double Withdraw(double amount)
        {
            if (amount < balance && amount > 0)
            {
                balance -= amount;
                transactionHistory.Add(amount * -1);
                return Balance;
            }
            else
                throw new ArgumentException("Invalid amount to withdraw");
        }

        public override string ToString()
        {
            string toReturn = "Account Number:\t" + accountNumber + "\nSort Code:\t" + sortCode + "\nOverdraft Limit:\t" + overdraftLimit + "\nBalance\t" + balance + "\n============Transaction History============\n";
            int counter = 1;
            foreach (var item in transactionHistory)
            {
                toReturn += "\nEntry #" + counter + ":\t" + item;
                ++counter;
            }


            return toReturn;
        }
    }
}
