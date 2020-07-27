using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApplication4.Models
{
  public class ControlSubject
    {


        [Key]
        [Column(Order = 1)]
        public long ControlId { get; set; }
        public Control control { get; set; }

        [Key]
        [Column(Order = 2)]
        public string subjectcode { get; set; }
        public  Subject subject { get; set; }
        

    }
}
