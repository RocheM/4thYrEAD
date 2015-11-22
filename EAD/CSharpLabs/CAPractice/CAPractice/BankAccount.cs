using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPractice
{
    public abstract class BankAccount
    {
        private string bankAccountNum;
        private double balance;

        public string BankAccountNum { get { return bankAccountNum; } }
        public double Balance { get; set; }

        protected BankAccount(string bankAccountNum)
        {
            this.bankAccountNum = bankAccountNum;
            this.balance = 0;
        }

        public abstract double MakeDeposit(double amount);
        public abstract double MakeWithdrawal(double amount);

    }
}
