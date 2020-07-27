using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4.Dto
{
  public  class SubjectDto
    {
   
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
 
        public long PatchId { get; set; }
        public List<RateDto> Rates { get; set; }
        public List<EvaluationDto> Evaluations { get; set; }

        public byte Semester { get; set; }
    }
}
