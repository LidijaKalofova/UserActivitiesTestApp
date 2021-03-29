using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UserActivitiesTestApp.Domain.Entities;

namespace UserActivitiesTestApp.BO.Models
{
    public class ActivityReportViewModel : IValidatableObject
    {
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date From")]
        public DateTime? DateFrom { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date To")]
        public DateTime? DateTo { get; set; }
        public ICollection<Activity> ActivityList { get; set; }
        
        [Display(Name = "Total Time Spent:")]
        public string TotalTimeSpent { get; set; }
        public EmailViewModel EmailViewModel { get; set; }
        public RandomUrlStorageViewModel RandomUrlStorageViewModel { get; set; }
        public ActivityViewModel ActivityViewModel { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateTo < DateFrom)
            {
                yield return new ValidationResult(
                $"Select date bigger than {DateFrom}.",
                new[] { nameof(DateTo) });
            }


        }
    }
}
