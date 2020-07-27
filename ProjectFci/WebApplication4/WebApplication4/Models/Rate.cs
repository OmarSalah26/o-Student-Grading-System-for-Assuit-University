
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebApplication4.Models
{
    public class Rate
    {
        [Key]
        public long id { get; set; }
        public string description { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        

       public ICollection<SubjectRate> SubjectRate { get; set; }


    }
}
