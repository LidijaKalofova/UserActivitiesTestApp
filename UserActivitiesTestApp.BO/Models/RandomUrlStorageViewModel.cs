using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserActivitiesTestApp.BO.Models
{
    public class RandomUrlStorageViewModel
    {
        public Guid Id { get; set; }
        public string UrlString { get; set; }
        public string ShortUrl { get; set; }        
        public string UserId { get; set; }
        [Display(Name ="Date From: ")]
        public DateTime? SelectedDateFrom { get; set; }
        [Display(Name = "Date To: ")]
        public DateTime? SelectedDateTo { get; set; }

    }
}
