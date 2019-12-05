using System;
using System.Collections.Generic;
using System.Text;

namespace TimerTest
{
    class Timer<T>
    {
        public void StartTimer(T t, int period)
        {
            System.Timers.Timer timer = new System.Timers.Timer(period);
            timer.Elapsed += (sender, e) => OnTimedEvent(sender, e, t);
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e, T t)
        {
            Console.WriteLine("Value: {0}, time: {1:HH:mm:ss.fff}", t, e.SignalTime);
        }


    }
}
