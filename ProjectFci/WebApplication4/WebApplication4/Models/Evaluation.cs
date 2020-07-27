
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApplication4.Models
{
    public class Evaluation
    {
        [Key]
        public long id { get; set; }
       
        public String Description { get; set; }

        public int Max { get; set; }
        public int Min { get; set; }


        public ICollection<SubjectEvaluation> SubjectEvaluation { get; set; }

        
       public ICollection<EvaluationSubjectStudent> EvaluationSubjectStudent { get; set; }

    }
}
