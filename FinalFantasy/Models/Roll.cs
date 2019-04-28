using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalFantasy.Models
{
    [Table("RollInfo")]
    public class Roll
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter the Rolls name.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,10}$", ErrorMessage = "Must be 1-10 upper or lowercase letters")]
        [StringLength(10, ErrorMessage = "The name must be less than {1} characters")]
        [Display(Name = "Roll Name")]
        public string RollName { get; set; }

        [StringLength(3, ErrorMessage = "The Roll abbreviation must be less than {1} characters")]
        [RegularExpression(@"^[A-Z''-'\s]{3,3}$", ErrorMessage = "Must be 3 uppercase letters")]
        [Column("RollAbr")]
        [Display(Name = "Roll Abbreviation")]
        public string RollAbr { get; set; }

        [Column("RaidDate")]
        [Display(Name = "Raid Date")]
        public DateTime RaidDate { get; set; }

        public virtual ICollection<Raid> Raids { get; set; }
    }
}