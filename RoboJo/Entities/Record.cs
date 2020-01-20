using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboJo.Entities
{
    class TimeRecord
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public String Description { get; set; }
        public String Hours { get; set; }
        public bool Billable { get; set; }
    }
}
