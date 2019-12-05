using System;

namespace IClockTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();

            Console.WriteLine(clock.Now);
            Console.WriteLine(clock.UtcNow);
            Console.WriteLine(clock.Today);

        }
    }
}
