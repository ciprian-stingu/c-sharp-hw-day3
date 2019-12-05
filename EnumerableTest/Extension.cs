using System;
using System.Collections.Generic;
using System.Text;

namespace EnumerableTest
{
    public static class Extension
    {
        private static string[] validTypes =
        {
            "Byte",
            "SByte",
            "Int32",
            "UInt32",
            "Single",
            "Double",
            "Char"


        };

        public static T Sum<T>(this IEnumerable<T> t)
        {
            var type = typeof(T);
            if(Array.IndexOf(validTypes, type.Name) < 0)
            {
                throw new ArgumentException("Invalid type!");
            }

            dynamic sum = 0;
            foreach (var tmp in t)
            {
                sum += tmp;
            }
            return sum;
        }

        public static T Product<T>(this IEnumerable<T> t)
        {
            var type = typeof(T);
            if (Array.IndexOf(validTypes, type.Name) < 0)
            {
                throw new ArgumentException("Invalid type!");
            }

            dynamic product = 1;
            foreach (var tmp in t)
            {
                product *= tmp;
            }
            return product;
        }

        public static T Min<T>(this IEnumerable<T> t)
        {
            var type = typeof(T);
            if (Array.IndexOf(validTypes, type.Name) < 0)
            {
                throw new ArgumentException("Invalid type!");
            }

            IEnumerator<T> enumerator = t.GetEnumerator();
            enumerator.MoveNext();
            dynamic min = enumerator.Current;
            while(enumerator.MoveNext())
            {
                if(min > enumerator.Current)
                {
                    min = enumerator.Current;
                }
            }

            return min;
        }

        public static T Max<T>(this IEnumerable<T> t)
        {
            var type = typeof(T);
            if (Array.IndexOf(validTypes, type.Name) < 0)
            {
                throw new ArgumentException("Invalid type!");
            }

            IEnumerator<T> enumerator = t.GetEnumerator();
            enumerator.MoveNext();
            dynamic max = enumerator.Current;
            while (enumerator.MoveNext())
            {
                if (max < enumerator.Current)
                {
                    max = enumerator.Current;
                }
            }

            return max;
        }

        public static T Average<T>(this IEnumerable<T> t)
        {
            dynamic avg = t.Sum();
            int count = 0;
            foreach (var tmp in t)
            {
                count++;
            }
            if (count > 0)
            {
                avg /= (T)Convert.ChangeType(count, typeof(T));
            }
            return avg;
        }
    }
}
