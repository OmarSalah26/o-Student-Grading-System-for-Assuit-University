using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebApplication4.Models
{
  public class Patch
    {
        [Key]
        public long ID { get; set; }

        public String PatchName { get; set; }

        public int PatchNumber { get; set; }
        public ICollection<Subject> Subjects { get; set; }

    }
}
