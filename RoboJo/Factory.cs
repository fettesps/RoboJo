using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboJo
{
    class Factory
    {
        public static IDAL OpenDB()
        {
            return new DAL();
        }
    }
}
