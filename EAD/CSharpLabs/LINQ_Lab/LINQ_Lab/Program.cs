using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Lab
{

    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Registration { get; set; }
        public double EngineSize { get; set; }

        public Car()
        {
            Make = "";
            Model = "";
            Registration = 0;
            EngineSize = 0;

        }

        public Car(string make, string model, int registration, double engineSize)
            : this()
        {
            Make = make;
            Model = model;
            Registration = registration;
            EngineSize = engineSize;

        }

        public override string ToString()
        {
            return "Make:\t\t" + Make + "\nModel:\t\t" + Model + "\nRegistration:\t" + Registration + "\nEngine Size:\t" +
                   EngineSize;
        }
    }

    class Fleet : IEnumerable<Car>
    {
        public List<Car> CarList { get; set; }

        public Fleet()
        {
            CarList = new List<Car>();
        }

        public void AddCar(Car toAdddCar)
        {
            CarList.Add(toAdddCar);
        }

        public Car this[int i] => CarList.ElementAt(i);
        public IEnumerator<Car> GetEnumerator()
        {
            foreach (var car in CarList)
            {
                yield return car;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main()
        {

            Car mazCar1 = new Car("Mazda", "Model1", 123454, 1600);
            Car mazCar2 = new Car("Mazda", "Model2", 546434, 2000);
            Car mazCar3 = new Car("Mazda", "Model3", 321412, 1200);
            Car mazCar4 = new Car("Mazda", "Model1", 903213, 1600);

            Car fordCar1 = new Car("Ford", "ModelF1", 434332, 1300);
            Car fordCar2 = new Car("Ford", "ModelF2", 444332, 1400);
            Car fordCar3 = new Car("Ford", "ModelF3", 454332, 1600);
            Car fordCar4 = new Car("Ford", "ModelF4", 464332, 1800);


            Fleet carFleet = new Fleet();
            
            carFleet.AddCar(mazCar1);
            carFleet.AddCar(mazCar2);
            carFleet.AddCar(mazCar3);
            carFleet.AddCar(mazCar4);

            carFleet.AddCar(fordCar1);
            carFleet.AddCar(fordCar2);
            carFleet.AddCar(fordCar3);
            carFleet.AddCar(fordCar4);

            //foreach (var car in carFleet)
            //{
            // Console.WriteLine(car + "\n");   
            //}

            var ascReg = 
                from c in carFleet
                orderby c.Registration ascending 
                select c;

           
            Console.WriteLine("Ascending Registration:\n\n");
            foreach (var car in ascReg)
            {
                Console.WriteLine(car + "\n");
            }



            Console.WriteLine("Mazda Only:\n\n");
            var mazdaList =
                from c in carFleet
                where c.Make.Equals("Mazda")
                select c;

            foreach (var mazda in mazdaList)
            {
                Console.WriteLine(mazda + "\n");
            }



            Console.WriteLine("Descending Engine Size:\n\n");
            var engSizeDesc=
                from c in carFleet
                orderby c.EngineSize descending 
                select c;

            foreach (var car in engSizeDesc)
            {
                Console.WriteLine(car + "\n");
            }


            Console.WriteLine("Engine Size 1600:\n\n");
            var engSize1600 =
                from c in carFleet
                where c.EngineSize.Equals(1600)
                orderby c.EngineSize ascending
                select c;

            foreach (var car in engSize1600)
            {
                Console.WriteLine(car + "\n");
            }

            Console.WriteLine("Engine Size 1600 or less:\n\n");
            var engSizeDesc1600Less =
                from c in carFleet
                where c.EngineSize < 1600
                orderby c.EngineSize ascending
                select c;

            Console.WriteLine(engSizeDesc1600Less.Count());

            Console.ReadKey();
        }
    }
}
