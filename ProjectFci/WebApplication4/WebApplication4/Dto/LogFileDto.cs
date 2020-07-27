using System;


namespace WebApplication4.Dto
{
   public class LogFileDto
    {
        public long id { get; set; }
        public long UserId { get; set; }
        public string Query { get; set; }
        public DateTime DataTime { get; set; }
    }
}
