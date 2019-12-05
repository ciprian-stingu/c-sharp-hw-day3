using System;
using System.Collections.Generic;
using System.Text;

namespace TimerTest
{
    static class TimerDelegate
    {

        public static void StartTimer(Object t, int period)
        {
            System.Timers.Timer timer = new System.Timers.Timer(period);
            timer.Elapsed += (sender, e) => OnTimedEvent(sender, e, t);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e, Object t)
        {
            Console.WriteLine("Value: {0}, time: {1:HH:mm:ss.fff}", t, e.SignalTime);
        }
    }
}
