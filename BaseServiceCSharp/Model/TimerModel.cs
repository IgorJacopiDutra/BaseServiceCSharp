using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BaseServiceCSharp.Model
{
    internal class TimerModel
    {
        public string Key { get; set; }
        public DateTime LastExecution { get; set; }
        public Timer Timer { get; set; }
    }
}
