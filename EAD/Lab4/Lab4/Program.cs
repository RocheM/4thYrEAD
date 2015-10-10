using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{

    class ModuleCAResults
    {



        private int[] scores;
        private const int max = 2;
        private int next;
        public string ModuleName { get; set; }
        public int Credits { get; set; }
        public string StudentName { get; set; }

        public ModuleCAResults()
        {
            scores = new int[max];
            next = 0;
        }

        public ModuleCAResults(string moduleName, int credits, string studentName)
        {
            ModuleName = moduleName;
            Credits = credits;
            StudentName = studentName;

            scores = new int[max];
            next = 0;
        }

        public int length
        {
            get { return next; }
        }

        public int this[int i]
        {
            get
            {
                if ((i >= 0) && (i < next))
                {
                    return scores[i];
                }
                else
                {
                    throw new ArgumentException("index is out of bounds: " + i);
                }
            }
            set
            {

                if (i >= 0)
                {
                    if (i < next)
                    {
                        scores[i] = value;
                    }
                    else if (i == next)
                    {
                        if (next < max)
                        {
                            scores[i] = value;
                            next++;
                        }
                        else
                        {
                            throw new ArgumentException("Scores are full");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Index out of bounds: " + i);
                    }
                }
                else
                {
                    throw new ArgumentException("Index out of bounds: " + i);
                }
            }

        }

        public override string ToString()
        {
            string details = "Module Name: " +  ModuleName + "\nCredits: " + Credits.ToString() + "\nStudent Name: " + StudentName + "\nScores: \n";


            int j = 1;
            foreach (int i in scores)
            {
                details += ("CA " + j + ":\t" + i.ToString()) + "\n";
                j++;
            }
            return details;
        }


    }

    class Calculator
    {

        public static double Divide(double x, double y)
        {

            if (y == 0)
            {
                throw new DivideByZeroException("Can't Divide " + x + " by zero.");
            }
            else
            {
                return x / y;
            }
        }


    }

    class Program
    {
        static void Main()
        {
            //Double x, y;

            //try
            //{
            //    Console.WriteLine("Enter First number to Divide:");
            //    x = Double.Parse(Console.ReadLine());
            //    Console.WriteLine("Enter Second number to Divide:");
            //    y = Double.Parse(Console.ReadLine());


            //    Console.WriteLine(x + "/" + y + " = " + Calculator.Divide(x, y));
            //    Console.ReadKey();
            //}
            //catch (FormatException)
            //{
            //    Console.WriteLine("Invalid Format, must be a number.");
            //    Console.ReadKey();

            //}
            //catch (OverflowException)
            //{
            //    Console.WriteLine("Overflow Exception");
            //    Console.ReadKey();
            //}
            //catch (DivideByZeroException)
            //{
            //    Console.WriteLine("Cannot Divide by zero");
            //    Console.ReadKey();
            //}

            try
            {

                ModuleCAResults mca = new ModuleCAResults("SDEV", 10, "John");
                mca[mca.length] = 10;
                mca[mca.length] = 20;
                        
                Console.WriteLine(mca.ToString());
                Console.ReadKey();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

        }
    }
}
