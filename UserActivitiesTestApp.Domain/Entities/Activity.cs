using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserActivitiesTestApp.Domain.Entities
{
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string ActivityName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime ActivityDateAdded { get; set; } = DateTime.Now;
        [Required]
        public DateTime ActivityStart { get; set; }
        [Required]
        public DateTime ActivityEnd { get; set; }
        public TimeSpan TimeSpent { get; set; }
        public string Description { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
