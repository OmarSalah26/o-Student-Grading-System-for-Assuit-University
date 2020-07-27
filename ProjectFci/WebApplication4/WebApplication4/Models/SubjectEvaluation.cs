using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace WebApplication4.Models
{
 public    class SubjectEvaluation
    {

        [Key]
        [Column(Order = 1)]
 
        public long EvaluationId { get; set; }
        public Evaluation Evaluation { get; set; }

        [Key]
        [Column(Order = 2)]
        public string subjectcode { get; set; }
        public Subject Subject { get; set; }

    }
}
