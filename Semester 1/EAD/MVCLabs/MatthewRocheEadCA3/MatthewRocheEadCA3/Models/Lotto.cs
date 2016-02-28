//Matthew Roche EAD CA3
//http://matthewrocheeadca3.azurewebsites.net/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;


namespace MatthewRocheEadCA3.Models
{
    public class Lotto
    {

        [Display(Name = "Numbers to draw cannot be larger than the maximum numbers")]
        public String Error;

        [Display(Name = "Lotto Numbers")]
        [Range(1, int.MaxValue, ErrorMessage ="Maximum Number Cannot exceed number of numbers to generate")]
        public List<int> numbers;

        [Display(Name = "Number of Numbers to draw")]
        [Range(1, 20, ErrorMessage = "Number must be a positive over 1 and less than 20")]  // Check if positive over 1
        public int numbersToDraw { get; set; }


        [Display(Name = "Max Number")]
        [Range(1, 100, ErrorMessage = "Number must be a positive over 1 and less than 100")]                              // Check if positive over 1
        public int maxNumber { get; set; }


        //Method to generate Required Numbers
        public void generateNumbers(int numbersToDrawInput, int maxNumberInput)
        {
            if (numbersToDrawInput >= maxNumberInput)
            {


            }
            else
            {
                Error = "Numbers to draw cannot be larger than the maximum numbers";

                numbers = new List<int>();

                Random randNum = new Random();
                int toAdd = 1;

                //Generates unique random numbers
                for (int i = 0; i <= numbersToDraw; i++)
                {
                    toAdd = randNum.Next(1, maxNumber);
                    if (!numbers.Contains(toAdd))
                        numbers.Add(toAdd);
                }


                numbers.Sort((a, b) => -1 * a.CompareTo(b)); 
            }
        }
    }


}