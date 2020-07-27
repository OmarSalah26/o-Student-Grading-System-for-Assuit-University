using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApplication4.Models
{
   public class ClemencyDegree
    {
        [Key]
        public long ID { get; set; }
        public string Describtion { get; set; }
        public int Max { get; set; }

        public int Min { get; set; }
        public ICollection<StudentEnrollSubject> StudentEnrollSubject { get; set; }


    }
}
