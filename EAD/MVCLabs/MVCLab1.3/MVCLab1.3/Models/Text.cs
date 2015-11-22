using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCLab1._3.Models
{
    public class Text
    {
        [Required(ErrorMessage = "Must Not be blank")]
        [StringLength(10, MinimumLength =10, ErrorMessage ="Number must equal 10 digits")]
        public string destination { get; set; }

        [Required(ErrorMessage = "Must Not be blank")]
        [StringLength(maximumLength:140, ErrorMessage = "Must not exceed 140 characters")]
        public string content { get; set; }
    }
}