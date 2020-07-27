using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApplication4.Models
{
    public class EvaluationSubjectStudent
    {
        [Key]
        [Column(Order = 1)]

        public string subjectcode { get; set; }
        public Subject subject { get; set; }
        [Key]
        [Column(Order = 2)]
        public long EvaluationID { get; set; }
        public Evaluation Evaluation { get; set; }
          [Key]
        [Column(Order = 3)]
        public long StudentSeatingNumber { get; set; }
        public Student Student { get; set; }

        public string  Abs { get; set; }

        public string Note { get; set; }
        public double Grade { get; set; }


    }
}
