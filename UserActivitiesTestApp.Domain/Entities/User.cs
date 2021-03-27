using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserActivitiesTestApp.Domain.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual ICollection<Activity> Activity { get; set; }
        public virtual ICollection<RandomUrlStorage> RandomUrlStorage { get; set; }
    }
}
