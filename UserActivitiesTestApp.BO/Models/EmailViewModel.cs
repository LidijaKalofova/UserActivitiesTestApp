using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserActivitiesTestApp.BO.Models
{
    public class EmailViewModel
    {             
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string SenderEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string SenderPassword { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email to")]
        public string EmailReceiver { get; set; }
    }
}
