using System;
using System.ComponentModel.DataAnnotations;

namespace FinalFantasy.ViewModels
{
    public class RaidtDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? RaidDate { get; set; }

        public int RollCount { get; set; }
    }
}