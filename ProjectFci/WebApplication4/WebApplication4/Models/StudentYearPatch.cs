using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApplication4.Models
{
    public class StudentYearPatch
    {
        [Key]
        [Column(Order = 1)]
        public long YearID { get; set; }
        public Year year { get; set; }
        [Key]
        [Column(Order = 2)]
        public long StudentSeatingNumber { get; set; }
        public Student student { get; set; }
        [Key]
        [Column(Order = 3)]
        public long PatchID { get; set; }
        public Patch patch { get; set; }
        public string StateForpatch { get; set; }
    }
}
