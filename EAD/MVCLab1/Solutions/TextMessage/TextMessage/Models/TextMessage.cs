using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TextMessage.Models
{
    // a text message has mobile number of recipient and content
    // data annotations for validation and messages
    public class SMSMessage
    {
        [Required(ErrorMessage = "Number must not be blank!")]                            
        [StringLength(10, MinimumLength=10, ErrorMessage="Number must be 10 digits long")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Number must be 10 digits long")]
        [DisplayName("To")]
        public String ToMobileNumber { get; set; }
       
        [Required(ErrorMessage = "Message must not be blank!")]
        [StringLength(140, ErrorMessage = "Message must be no more than 140 characters long")]
        [DisplayName("Message")]
        public String Content { get; set; }
    }
}