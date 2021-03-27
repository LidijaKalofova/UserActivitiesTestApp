using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UserActivitiesTestApp.Domain.Entities;

namespace UserActivitiesTestApp.BO.Models
{
    public class ActivityViewModel : IValidatableObject
    {
        public Guid Id { get; set; }
        [Display(Name ="Activity Name")]
        public string ActivityName { get; set; }
        [Required]
        public DateTime ActivityDateAdded { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        [Display(Name = "Activity Start:")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm A}", ApplyFormatInEditMode = true)]
        public DateTime ActivityStart { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Activity End:")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm A}", ApplyFormatInEditMode = true)]
        public DateTime ActivityEnd { get; set; }
        [Display(Name = "Time spent")]
        public string TimeSpent { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public long ActivityTimeSpent { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {            
            if (ActivityEnd < ActivityStart)
            {
                yield return new ValidationResult(
                $"Select date bigger than {ActivityStart}.",
                new[] { nameof(ActivityEnd) });
            }            
        }
    }
}
