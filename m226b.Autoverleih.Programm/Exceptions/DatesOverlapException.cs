using System;
using System.Collections.Generic;
using System.Text;

namespace m226b.Autoverleih.Programm.Exceptions
{
    public class DatesOverlapException : Exception
    {
        public DatesOverlapException()
        {
        }

        public DatesOverlapException(string message) : base(message)
        {
        }

        public DatesOverlapException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
