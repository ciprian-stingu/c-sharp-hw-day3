using System;
using System.Collections.Generic;
using System.Text;
using IClockTest.Struct;

namespace IClockTest.Interface
{
    public interface IClock
    {
        public DateTime Now
        {
            get;
        }

        public DateTime UtcNow
        {
            get;
        }

        public BusinessDate Today
        {
            get;
        }

    }
}
