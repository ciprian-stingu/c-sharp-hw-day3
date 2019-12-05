using System;
using System.Collections.Generic;
using System.Text;
using IClockTest.Struct;

namespace IClockTest
{
    public class Clock : Interface.IClock
    {
        
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        public DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

        public BusinessDate Today
        {
            get
            {
                DateTime now = Now;
                return new BusinessDate(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, 0, now.Kind));
            }
        }
    }

}
