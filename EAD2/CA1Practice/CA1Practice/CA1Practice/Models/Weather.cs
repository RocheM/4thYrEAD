using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CA1Practice.Models
{
    public class Weather
    {
        
        [Required(ErrorMessage = "Invalid City")]
        public string city { get; set; }

        [Range(minimum:-50, maximum:50, ErrorMessage ="Invalid Temp")]
        public Double temperature { get; set; }

        [Range(minimum:0, maximum:200, ErrorMessage ="Invalid Wind Speed")]
        public Double windSpeed { get; set; }

        [Required(ErrorMessage ="Invalid Condititions")]
        public String conditions { get; set; }

        public bool weatherWarning { get; set; }


    }
}