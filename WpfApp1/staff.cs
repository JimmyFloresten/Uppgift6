using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class staff
    {
        public int staff_id { get; set; }

        public string fname { get; set; }

        public int phone { get; set; }

        public override string ToString()
        {
            return fname + " " + phone;
 
        }
    }
}
