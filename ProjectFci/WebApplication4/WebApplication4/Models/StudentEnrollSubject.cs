using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApplication4.Models
{
 public class StudentEnrollSubject
    {
        [Key]
        [Column(Order = 1)]


        public string subjectcode { get; set; }
        public Subject subject { get; set; }

        [Key]
        [Column(Order = 2)]
       
        public long StudentSeatingNumber { get; set; }

        public Student Student { get; set; }

        [ForeignKey("")]

        public long ClemencyDegreeID { get; set; }
        public ClemencyDegree ClemencyDegree { get; set; }
       
        [ForeignKey("")]
        public long YearID { get; set; }
        public Year Year { get; set; }

        public String StateStudentEnrollSubject { get; set; }
        // الدرجه النهائيه لكل ماده
        public double TotalGrade { get; set; }

        public DateTime DateTimeENL { get; set; }
        public DateTime DateTimeCLD { get; set; }
        public String RateingForGrade { get; set; }




    }
}
