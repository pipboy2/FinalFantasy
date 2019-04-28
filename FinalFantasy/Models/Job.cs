using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalFantasy.Models
{
    public class Job
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JobID { get; set; }
        [Required]
        [ConcurrencyCheck]
        [MaxLength(15, ErrorMessage = "The maximum length is 24 characters")]
        [MinLength(4, ErrorMessage = "The minimum length is 5 characters")]
        [Index(IsUnique = true)]
        public string Title { get; set; }
        [Range(1, 6)]
        public int Hours { get; set; }

        public virtual ICollection<Raid> Raids { get; set; }
    }
}