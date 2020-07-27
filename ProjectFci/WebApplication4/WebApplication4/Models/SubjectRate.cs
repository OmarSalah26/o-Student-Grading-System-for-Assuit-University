using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApplication4.Models
{
public  class SubjectRate
    {
        [Key]
        [Column(Order = 1)]
        public string subjectcode { get; set; }
        public Subject Subject { get; set; }

        [Key]
        [Column(Order = 2)]

        public long RateId { get; set; }
        public Rate Rate { get; set; }

    }
}
