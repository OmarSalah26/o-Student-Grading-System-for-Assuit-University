using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
 public   class section
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        


    }
}
