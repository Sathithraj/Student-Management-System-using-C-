using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSFORBIT
{
    internal class DBConnection
    {
        public string getConnection()
        {
            string con = "server=localhost; database=project; user=root; password=";
            return con;
        }
    }
}
