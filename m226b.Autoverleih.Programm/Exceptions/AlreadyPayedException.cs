using System;
using System.Collections.Generic;
using System.Text;

namespace m226b.Autoverleih.Programm.Exceptions
{
    public class AlreadyPayedException : Exception
    {
        public AlreadyPayedException()
        {
        }

        public AlreadyPayedException(string message) : base(message)
        {
        }

        public AlreadyPayedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
