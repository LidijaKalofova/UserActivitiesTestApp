using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserActivitiesTestApp.Domain.Entities
{
    public class Activity : BaseEntity
    {        
        [Required]
        public string ActivityName { get; set; }
        [Required]
        public DateTime ActivityStart { get; set; }
        [Required]
        public DateTime ActivityEnd { get; set; }
        public long ActivityTimeSpent { get; set; }
        public string TimeSpent { get; set; }
        public string Description { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
