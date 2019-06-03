using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class guardian
    {
        public int guardian_id { get; set; }
        public string fname { get; set; }
        
        public string lname { get; set; }
        public int phone { get; set; }

        public override string ToString()
        {
            return fname + " " + lname + " " + phone;
        }
    }
}
