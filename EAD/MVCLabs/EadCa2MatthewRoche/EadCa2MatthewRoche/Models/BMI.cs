using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


//Matthew Roche X00102929

namespace EadCa2MatthewRoche.Models
{
    public enum Category{  Underweight = 1, Normal, Overweight, Obese}

    public class BMI
    {

        [Required(ErrorMessage = "Required field!")]
        [Range(5, int.MaxValue, ErrorMessage = "Must be greater than 5 stones")]
        //[RegularExpression(@"(?:\d*\.)?\d+", ErrorMessage = "Must only be positive numbers")]
        [Display(Name = "Stones")]
        public int stones { get; set; }             

        [Required(ErrorMessage = "Required field!")]
        [Display(Name = "Pounds")]
        [RegularExpression(@"(?:\d*\.)?\d+", ErrorMessage = "Must only be positive numbers")]
        public int lbs { get; set; }             

        [Required(ErrorMessage = "Required field!")]
        [Range(4, int.MaxValue, ErrorMessage = "Must be greater than 4 feet")]
        [RegularExpression(@"(?:\d*\.)?\d+", ErrorMessage = "Must only be positive numbers")]
        [Display(Name = "Feet")]
        public int feet { get; set; }             

        [Required(ErrorMessage = "Required field!")]
        [RegularExpression(@"(?:\d*\.)?\d+", ErrorMessage = "Must only be positive numbers")]
        [Display(Name = "Inches")]
        public int inches { get; set; }

        [Display(Name = "Category")]
        public Category weightCategory{ get; set; }

        [Display(Name = "BMI Number")]
        public double BMINumber { get; set; }


        public void calculateBMI()
        {
            const double KgPerStone = 6.35029;
            const double PoundsPerStone = 14;

            double totalStone = stones + (lbs / PoundsPerStone);
            double kgs = totalStone * KgPerStone;

            BMINumber = (convertWeight() / Math.Pow(convertHeight(),2));

            if (BMINumber <= 18.4)
                weightCategory = Category.Underweight;
            else if (BMINumber > 18.5 && BMINumber <= 24.9)
                weightCategory = Category.Normal;
            else if (BMINumber > 25 && BMINumber <= 29.9)
                weightCategory = Category.Overweight;
            else if (BMINumber > 30)
                weightCategory = Category.Obese;

            BMINumber = Math.Round(BMINumber, 1);
          

        }

        public double convertWeight()
        {
            const double KgPerStone = 6.35029;
            const double PoundsPerStone = 14;

            double totalStone = stones + (lbs / PoundsPerStone);
            return totalStone * KgPerStone;
        }

        public double convertHeight()
        {
            double feetToInches = (feet * 12.00000) + 1;
            double totalInches = feetToInches + inches;


            return totalInches/39.37008;
        }

    }
}