using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Person
    {
        [Required (ErrorMessage = "Requires a name")]
        [StringLength (100, MinimumLength =10, ErrorMessage ="Must be over 10 characters")]
        [Display (Name ="Name")]
        public String name { get; set; }

        [Required(ErrorMessage ="Requires a Phone Number")]
        [StringLength(10, MinimumLength =10, ErrorMessage ="Must be 10 digits")]
        [RegularExpression(@"(?:\d*\.)?\d+", ErrorMessage ="Must only be numbers")]
        [Display(Name = "Phone Number")]
        public String Phone { get; set; }

        [Required(ErrorMessage ="Requires an Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="Invalid Email")]
        [Display(Name = "Email")]
        public String Email { get; set; }

    }
}
