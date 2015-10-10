using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public interface IHasVoume
    {
        double Volume();
    }

    //public abstract class ThreeDShape 
    //{

    //    private string type;

    //    public string Type
    //    {
    //        get { return type; }
    //    }

    //    public abstract double Volume
    //    {
    //        get;
    //    }


    //    protected ThreeDShape(String s)
    //    {
    //        type = s;
    //    }

    //    public override string ToString()
    //    {
    //        return ("Type is: " + Type + "\nVolume is: " + Volume);
    //    }

    //}

    public class Sphere : IHasVoume
    {
        // auto property
        public double radius
        {
            get;
            set;
        }


        public double Volume()
        {

            double rSq = Math.Pow(radius, 3);
            return 0.75 * 3.14149 * rSq;

        }

        // default constructor
        public Sphere(double radius)
        {
            this.radius = radius;
        }

        public override string ToString()
        {
            return "Sphere Radius:\t" + this.radius + "\nSphere Volume:\t" + Volume().ToString("0.00");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            IHasVoume[] shapes = new IHasVoume[10];

            shapes[0] = new Sphere(10);
            shapes[1] = new Sphere(20);
            shapes[2] = new Sphere(30);
            shapes[3] = new Sphere(40);
            shapes[4] = new Sphere(50);
            shapes[5] = new Sphere(60);
            shapes[6] = new Sphere(70);
            shapes[7] = new Sphere(80);
            shapes[8] = new Sphere(90);


            foreach (Sphere s in shapes)
            {
                Console.WriteLine(s + "\n");
            }

            Console.ReadKey();
        }
    }
}
