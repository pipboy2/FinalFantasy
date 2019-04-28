using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalFantasy.Models
{
    public enum Day
    {
        M, TU, W, TH, F
    }

    public class Raid
    {
        [Display(Name = "Raid ID")]
        public int RaidID { get; set; }
        [Index]
        [Display(Name = "Job ID")]
        public int JobID { get; set; }
        [Index]
        [Display(Name = "Roll")]
        public int RollID { get; set; }
        public Day? Day { get; set; }

        public virtual Job Job { get; set; }
        public virtual Roll Roll { get; set; }
    }
}
