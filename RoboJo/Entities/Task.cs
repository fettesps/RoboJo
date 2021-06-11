using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboJo.Entities
{
    class Task
    {
        public int Task_ID { get; set; }
        public String Name { get; set; }
        public String details { get; set; }
        public int Project_ID { get; set; }
    }
}
