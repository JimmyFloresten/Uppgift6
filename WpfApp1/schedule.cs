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
    
        public DateTime? sickleave { get; set; }

        public string pick_up { get; set; }
        
        public bool goalone { get; set; }

        public int child_id {get; set; }

        public DateTime? leave { get; set; }

        public TimeSpan schedule_dateleaving { get; set; }

        public TimeSpan schedule_datecoming { get; set; }

        public string weekday { get; set; }

        public DateTime arrivaldate { get; set; }

        public override string ToString()
        {
            return child_id + " " + breakfast + " " + sickleave.Value + " " + pick_up + " " + goalone + " " + leave + " " + weekday + " " + schedule_datecoming + " " + schedule_dateleaving + " " + arrivaldate;
        }

    }
}
