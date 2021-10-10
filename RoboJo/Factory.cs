using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboJo
{
    public class Factory
    {
        public static IDAL OpenDB()
        {
            return new DAL();
        }

        public static IBLL OpenBLL()
        {
            return new BLL();
        }
    }
}
