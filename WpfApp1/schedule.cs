using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class schedule
    {
        public int schedule_id { get; set; }

        public bool breakfast { get; set; }
    
        public bool sickleave { get; set; }

        public string pick_up { get; set; }
        
        public bool goalone { get; set; }

        public int child_id {get; set; }

        public int leave { get; set; }

        public string weekday { get; set; }

        public override string ToString()
        {
            return child_id + " " + breakfast + " " + sickleave + " " + pick_up + " " + goalone + " " + leave + " " + weekday;
        }

    }
}
