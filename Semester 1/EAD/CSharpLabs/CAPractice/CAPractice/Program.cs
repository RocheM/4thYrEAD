using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CurrentAccount newAccount = new CurrentAccount("A1234", 200);
                newAccount.MakeDeposit(200);
                newAccount.MakeDeposit(100);
                newAccount.MakeDeposit(100);
                newAccount.MakeDeposit(100);
                newAccount.MakeDeposit(100);
                newAccount.MakeWithdrawal(100);
                newAccount.MakeWithdrawal(100);
                newAccount.MakeWithdrawal(50);
                newAccount.MakeWithdrawal(10);
                newAccount.MakeWithdrawal(10);
                newAccount.MakeWithdrawal(10);
                newAccount.MakeWithdrawal(330);


                Console.WriteLine(newAccount);
                Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }


        }
    }
}
