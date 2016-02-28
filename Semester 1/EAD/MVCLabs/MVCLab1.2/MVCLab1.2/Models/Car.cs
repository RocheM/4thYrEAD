using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLab1._2.Models
{

    public enum engineType { petrol, diesel, hybrid };
    public class Car
    {
        public string make { get; set; }
        public string model { get; set; }
        public double enineSize { get; set; }
        public engineType engineType { get; set; }

    }
}