using System;

namespace Lab5
{
    class Program
    {
        public enum CurrencyTypes
        {
            Euro, Dollar, Yen
        }


        struct Money
        {
            private const double EuroToDollar = 1.13;
            private const double EuroToYen = 134.90;
            private const double DollarToEuro = 0.89;
            private const double DollarToYen = 119.83;

            private CurrencyTypes Currency { get; set; }
            private double Amount { get; set; }


            public Money(CurrencyTypes curr, double amount)
                : this()
            {
                Currency = curr;
                Amount = amount;
            }

            public double Conversion(CurrencyTypes toCurrency)
            {
                if (Currency == toCurrency)
                    return Amount;
                else if (Currency == CurrencyTypes.Yen)
                {
                    if (toCurrency == CurrencyTypes.Dollar)
                        return Amount/DollarToYen;
                    else
                        return Amount/EuroToYen;
                }
                else if (Currency == CurrencyTypes.Euro)
                {
                    if (toCurrency == CurrencyTypes.Dollar)
                        return Amount*EuroToDollar;
                    else
                        return Amount*EuroToYen;
                }
                else if (Currency == CurrencyTypes.Dollar)
                {
                    if (toCurrency == CurrencyTypes.Euro)
                        return Amount*DollarToEuro;
                    else
                        return Amount*DollarToYen;
                }

                return Amount;
            }
             
            public static Money operator +(Money money1, Money money2)
            {
                money2.Amount = money2.Conversion(money1.Currency);
                money2.Currency = money1.Currency;



                return new Money(money1.Currency, money1.Amount + money2.Amount);
            }

            public override string ToString()
            {
                return Currency + ": " + this.Amount;
            }
        }




        static void Main(string[] args)
        {

            var dollar = new Money(CurrencyTypes.Dollar, 20.0);
            Console.WriteLine(dollar.ToString());
            var euro = new Money(CurrencyTypes.Euro, dollar.Conversion(CurrencyTypes.Euro));
            Console.WriteLine(euro.ToString());
            var yen = new Money(CurrencyTypes.Yen, dollar.Conversion(CurrencyTypes.Yen));
            Console.WriteLine(yen.ToString());
            Console.ReadKey();


            var euro2 = new Money(CurrencyTypes.Euro, 500);
            Console.WriteLine(euro2.ToString());
            var dollar2 = new Money(CurrencyTypes.Dollar, euro2.Conversion(CurrencyTypes.Dollar));
            Console.WriteLine(dollar2.ToString());
            var yen2 = new Money(CurrencyTypes.Yen, euro2.Conversion(CurrencyTypes.Yen));
            Console.WriteLine(yen2.ToString());
            Console.ReadKey();

            var euro3 = new Money(CurrencyTypes.Euro, 1000);
            var dollar3 = new Money(CurrencyTypes.Dollar, 1000);
            var euro4 = euro3 + dollar3;


            Console.WriteLine(euro3 + " + "  + dollar3 + " = " + euro4);
            Console.ReadKey();


        }
    }
}
