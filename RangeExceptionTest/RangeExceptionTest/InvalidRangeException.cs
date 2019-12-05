using System;
using System.Collections.Generic;
using System.Text;

namespace RangeExceptionTest
{
    class InvalidRangeException<T> : Exception
    {
        public T Minim { get; private set; }
        public T Maxim { get; private set; }

        private string message = string.Empty;

        public InvalidRangeException(string message) : base(message)
        {
            this.message = message;

            var type = typeof(T);
            if(type.Name == "Int32")
            {
                Minim = (T)Convert.ChangeType("0", type);
                Maxim = (T)Convert.ChangeType("100", type);
            }
            else if(type.Name == "DateTime")
            {
                Minim = (T)Convert.ChangeType("1.1.1980", type);
                Maxim = (T)Convert.ChangeType("12.31.2013", type);
            }
            else
            {
                throw new Exception("Unknown type!");
            }
            
        }

        public InvalidRangeException(string message, T minim, T maxim) : base(message)
        {
            this.message = message;
            Minim = minim;
            Maxim = maxim;
        }

        public override string Message
        {
            get { return message + ", Min: " + Minim + ", Max: " + Maxim; }
        }
    }
}

