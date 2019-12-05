using System;

namespace TimerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer<int> t1 = new Timer<int>();
            t1.StartTimer(1, 1000);

            Timer<double> t2 = new Timer<double>();
            t2.StartTimer(99.9, 1500);

            Timer<string> t3 = new Timer<string>();
            t3.StartTimer("wwwww", 1250);

            DelegateForTimer d = new DelegateForTimer(TimerDelegate.StartTimer);
            d(41, 2500);

            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }

        public delegate void DelegateForTimer(Object t, int p);
    }
}
