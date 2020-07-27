using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApplication4.Models
{
    public class Year
    {

        [Key]
        public long id { get; set; }
        public int YearNumber { get; set; }
       


    }
}
