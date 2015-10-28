using System;

namespace UnitTestingLab
{
    class Program
    {
        

        static void Main()
        {
            try
            {
                BankAccount b = new BankAccount("Hello", "Test", 100.50);
                b.Deposit(2000);
                b.Withdraw(-200);
                Console.WriteLine(b.ToString());
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
