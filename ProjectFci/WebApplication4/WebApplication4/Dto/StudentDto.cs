using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4.Dto
{
    public class StudentDto
    {
     
        public long SeatingNumber { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string BirthPlace { get; set; }
        public string NationalIdNumber { get; set; }
     
        public long SectionID { get; set; }
    }
}
