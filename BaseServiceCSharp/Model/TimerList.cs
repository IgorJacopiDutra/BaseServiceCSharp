using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BaseServiceCSharp.Model
{
    internal class TimersList
    {
        public List<TimerModel> Timers { get; set; }

        public TimersList()
        {
            Timers = new List<TimerModel>();
        }

        public void AddTimer(string key, int interval, ElapsedEventHandler handler)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Key cannot be null or empty.");
            }


            {
                TimerModel existingTimer = Timers.FirstOrDefault(t => t.Key == key);

                if (existingTimer == null)
                {
                    TimerModel newTimer = new TimerModel();
                    newTimer.Key = key;
                    newTimer.Timer = new Timer(interval);
                    newTimer.Timer.AutoReset = true;

                    newTimer.Timer.Elapsed += handler;

                    Timers.Add(newTimer);
                }
                else
                {
                    throw new ArgumentException($"A timer with the key '{key}' already exists.");
                }
            }
        }

        public TimerModel GetTimer(string key)
        {
            return Timers?.Where(x => x.Key == key).FirstOrDefault();
        }

        public DateTime GetLastExecution(string key)
        {
            return (DateTime)(Timers?.Where(x => x.Key == key).FirstOrDefault().LastExecution);
        }
    }
}