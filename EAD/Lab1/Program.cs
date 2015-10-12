using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public abstract class ThreeDShape
    {

        private string type;

        public string Type
        {
            get { return type;  }
        }

        public abstract double Volume			
        {
            get;
        }

        
        protected ThreeDShape(String s)
        {
            type = s;
        }
        
        public override string ToString()
        {
            return ("Type is: " + Type + "\nVolume is: " + Volume);
        }

    }

    public class Sphere : ThreeDShape
    {
        // auto property
        public double radius
        {
            get;
            set;
        }


        public override double Volume
        {
            get
            {
                double rSq = Math.Pow(radius, 3);

                return 0.75 * 3.14149 * rSq;
            }
        }

        // default constructor
        public Sphere(String type, double radius)
            : base(type)
        {
            this.radius = radius;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {


            Sphere[] spheres = new Sphere[10];

            spheres[0] = new Sphere("Sphere 1", 10);
            spheres[1] = new Sphere("Sphere 2", 20);
            spheres[2] = new Sphere("Sphere 3", 30);
            spheres[3] = new Sphere("Sphere 4", 40);
            spheres[4] = new Sphere("Sphere 5", 50);
            spheres[5] = new Sphere("Sphere 6", 60);
            spheres[6] = new Sphere("Sphere 7", 70);
            spheres[7] = new Sphere("Sphere 8", 80);
            spheres[8] = new Sphere("Sphere 9", 90);
            spheres[9] = new Sphere("Sphere 10", 100);


            

            foreach (Sphere s in spheres){

                Console.WriteLine(s + "\n");

            }

            Console.ReadKey();
        }
    }
}
