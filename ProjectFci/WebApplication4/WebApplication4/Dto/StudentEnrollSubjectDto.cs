using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4.Dto
{
   public class StudentEnrollSubjectDto
    {
       

        public string subjectcode { get; set; }

        
        public long StudentSeatingNumber { get; set; }


        

        public long ClemencyDegreeID { get; set; }

        
        public long YearID { get; set; }

        public String StateStudentEnrollSubject { get; set; }

        //  ناتج تجميع الدراجات 
        public double TotalGrade { get; set; }

        public DateTime DateTimeENL { get; set; }
        public DateTime DateTimeCLD { get; set; }
        public String RateingForGrade { get; set; }



    }
}
