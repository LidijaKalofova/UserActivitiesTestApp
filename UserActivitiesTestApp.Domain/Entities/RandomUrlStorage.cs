using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserActivitiesTestApp.Domain.Entities
{
    public class RandomUrlStorage : BaseEntity
    {
        public string UrlString { get; set; }
        public string ShortUrl { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public DateTime? SelectedDateFrom { get; set; }
        public DateTime? SelectedDateTo { get; set; }
    }
}
