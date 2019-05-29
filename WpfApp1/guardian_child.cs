using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp1
{
    class guardian_child
    {
        public int child_id { get; set; }

        public int guardian_id { get; set; }

        public override string ToString() 
        {
            return guardian_id + " " + child_id;
        }
   
    }
}
