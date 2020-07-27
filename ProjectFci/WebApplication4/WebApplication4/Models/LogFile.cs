using System;
using System.ComponentModel.DataAnnotations;


namespace WebApplication4.Models
{
  public   class LogFile
    {
        [Key]
        public long id { get; set; }
        public long UserId { get; set; }
        public string Query { get; set; }
        public DateTime DataTime { get; set; }


    }
}
