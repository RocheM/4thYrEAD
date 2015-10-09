using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{

    class Vertex
    {

        public int PointX {get; set;}
        public int PointY { get; set;}
        


        public Vertex()
            : this(0, 0)
        {

        }

        public Vertex(int pointX, int pointY)
        {

            PointX = pointX;
            PointY = pointY;

        }


        public override string ToString()
        {
            return "X:" + PointX + "\nY:" + PointY;
        }

    }

    class Shape
    {
        private string color;

        public Shape(string color)
        {
            this.color = color;
        }


    }

    class Test
    {
        public static void Main()
        {
            Vertex testV = new Vertex { PointX = 5, PointY = 5 };
            Console.WriteLine(testV);
            Console.ReadKey();

        }
    }
}
