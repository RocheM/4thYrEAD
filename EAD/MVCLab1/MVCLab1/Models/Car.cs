using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MVCLab1.Models
{
    public class Car
    {
        [Required]
        public string Make { get; set; }

    }
}