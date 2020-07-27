using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4.Dto
{
  public   class EvaluationSubjectStudentDto
    {

        public string subjectcode { get; set; }
       
        public long EvaluationID { get; set; }
     
        public long StudentSeatingNumber { get; set; }
    

        public string Abs { get; set; }

        public string Note { get; set; }
        public double Grade { get; set; }

    }
}
