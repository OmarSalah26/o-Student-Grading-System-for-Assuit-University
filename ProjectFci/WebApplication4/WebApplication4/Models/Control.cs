using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace WebApplication4.Models
{
  public class Control
    {
        [Key]
        public long ID { get; set; }
        
        public string ControlName { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey("")]
        public long userID { get; set; }
        public User user { get; set; }

        public ICollection<ControlSubject> ControlSubjects { get; set; }




    }
}
