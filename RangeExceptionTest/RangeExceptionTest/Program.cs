using System;

namespace RangeExceptionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            InvalidRangeException<int> intRangeException1 = new InvalidRangeException<int>("Range exception");
            InvalidRangeException<int> intRangeException2 = new InvalidRangeException<int>("Range exception", 0, 102);

            InvalidRangeException<DateTime> dateTimeRangeException1 = new InvalidRangeException<DateTime>("Range exception");
            InvalidRangeException<DateTime> dateTimeRangeException2 = new InvalidRangeException<DateTime>("Range exception", new DateTime(1980, 1, 1), new DateTime(2018, 12, 31));

            try
            {
                int FirstNo = -1;
                if (FirstNo < intRangeException1.Minim)
                {
                    throw intRangeException1;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            try
            {
                int SecondNo = 103;
                if (SecondNo > intRangeException2.Maxim)
                {
                    throw intRangeException2;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            try
            {
                DateTime FirstDate = DateTime.Parse("12.12.1978");
                if (FirstDate < dateTimeRangeException1.Minim)
                {
                    throw dateTimeRangeException1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            try
            {
                DateTime SecondDate = DateTime.Parse("12.28.2019");
                if (SecondDate > dateTimeRangeException2.Maxim)
                {
                    throw dateTimeRangeException2;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
