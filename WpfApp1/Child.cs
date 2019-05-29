using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Child
    {
        public int child_id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }

        public string special_needs { get; set; }

        public override string ToString()
        {
            return child_id + " " + fname + " " + lname + " " + special_needs;
        }
    }
}
