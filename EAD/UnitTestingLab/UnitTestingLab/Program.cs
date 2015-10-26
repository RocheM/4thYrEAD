using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingLab
{
    class Program
    {

        static void Main()
        {

            try
            {

            BankAccount b = new BankAccount("Hello", "Test", 100.50);
            b.Deposit(200);
            b.Deposit(200);
            b.Withdraw(100);

            Console.WriteLine(b);
            Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.ReadKey();
            }
        }
    }
}
