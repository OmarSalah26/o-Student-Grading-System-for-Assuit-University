using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApplication4.Models
{
  public   class Subject
    {
        [Key]

        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }

        [ForeignKey("")]
        public long PatchId { get; set; }
        public Patch Patch { get; set; }

        public byte Semester { get; set; }

        public ICollection<ControlSubject> ControlSubjects { get; set; }

        public ICollection< SubjectEvaluation> SubjectEvaluation { get; set; }

        
        public ICollection<SubjectRate> SubjectRate { get; set; }

        
        public ICollection<StudentEnrollSubject> StudentEnrollSubject { get; set; }
        public ICollection<EvaluationSubjectStudent> EvaluationSubjectStudent { get; set; }


       

    }
}
