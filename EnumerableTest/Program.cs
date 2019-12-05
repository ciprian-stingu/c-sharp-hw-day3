using System;
using System.Collections.Generic;

namespace EnumerableTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int>{ 1, 2, 3};
            int sum = ints.Sum();
            Console.WriteLine("Sum: " + sum);

            List<char> chars = new List<char> { '2', 'a', '+', (char)0x20 };
            char min = chars.Min();
            Console.WriteLine("Min: '" + min + "'");

            List<sbyte> bytes = new List<sbyte> { -126, 0, 4, 127 };
            sbyte max = bytes.Max();
            Console.WriteLine("Max: " + max);

            List<double> doubles = new List<double> { -1.0, 2.0, 5.0, 25 };
            double avg = doubles.Average();
            Console.WriteLine("Average: " + avg);

            List<string> strings = new List<string> { "aaa", "b", "dddd" };
            try
            {
                strings.Min();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
