using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4.Dto
{
 public  class StudentYearPatchDto
    {

        public long YearID { get; set; }
    
        public long StudentSeatingNumber { get; set; }
       
        public long PatchID { get; set; }
      
        public string StateForpatch { get; set; }

    }
}
