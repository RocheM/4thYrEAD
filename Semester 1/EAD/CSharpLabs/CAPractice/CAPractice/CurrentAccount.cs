using System;
using System.Collections.Generic;

namespace CAPractice
{
    public class CurrentAccount : BankAccount
    {

        private double overdraftLimit;
        private List<AccountTransaction> transactionHistory;

        public double OverdraftLimit
        { get { return overdraftLimit; } }

        public List<AccountTransaction> Transactionhistory {get { return transactionHistory; } }


        public CurrentAccount(string bankAccountNum, double overdraftLimit)
            : base(bankAccountNum)
        {
            this.overdraftLimit = overdraftLimit;
            transactionHistory = new List<AccountTransaction>();
        }

        public override double MakeDeposit(double amount)
        {
            Balance += amount;
            transactionHistory.Add(new AccountTransaction(TransactionType.Deposit, amount));

            return Balance;

        }

        public override double MakeWithdrawal(double amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentException("Not Enough Funds to withdraw");
            }
            else
            {
                Balance -= amount;
                transactionHistory.Add(new AccountTransaction(TransactionType.Withdrawal, amount * -1));
                return Balance;
            }
        }

        public override String ToString()
        {
            string toReturn;

            int counter = 1;
            toReturn = "Account Num:\t" + BankAccountNum + "\nBalance:\t" + Balance + "\n====Transaction History====";

            foreach (var transaction in transactionHistory)
            {
                toReturn += "\n" + "#" +  counter + ":\t" + transaction;
                counter++;
            }

            return toReturn;
        }
    }
}