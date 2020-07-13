using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepTracker.Data
{
    public class DayStepPair
    {
        public int Stepcount { get; set; }
        public int Daynumber { get; set; }

        public DayStepPair()
        {

        }
        public DayStepPair(int count, int num)
        {
            Stepcount = count;
            Daynumber = num;
        }
    }
}
