using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class attendence
    {
        public int attendence_id { get; set; }

        public int clas_id { get; set; }

        public int staff_id { get; set; }

        public int child_id { get; set; }

        public DateTime arrival { get; set; }

        public DateTime departure { get; set; }

        public override string ToString()
        {
            return child_id + " " + staff_id + " " + arrival + " " + departure;
 
        }
    }
}
