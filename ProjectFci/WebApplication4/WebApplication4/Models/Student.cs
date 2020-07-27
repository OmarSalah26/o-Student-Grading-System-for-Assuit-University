using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Student
    {


        [Key]
   
        public long SeatingNumber { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string BirthPlace { get; set; }
        public string NationalIdNumber { get; set; }
        [ForeignKey("")]
        public long SectionID { get; set; }
        public section section { get; set; }
        public ICollection<StudentEnrollSubject> StudentEnrollSubject { get; set; }
        public ICollection<EvaluationSubjectStudent> EvaluationSubjectStudent { get; set; }
        
         public ICollection<StudentYearPatch> StudentYearPatch { get; set; }


    }
}
