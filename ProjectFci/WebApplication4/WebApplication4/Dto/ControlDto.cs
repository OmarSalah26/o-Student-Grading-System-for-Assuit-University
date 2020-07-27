using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4.Dto
{
    public class ControlDto
    {
        public long ID { get; set; }

        public string ControlName { get; set; }
        public DateTime CreationDate { get; set; }

        public long userID { get; set; }
    }
}
