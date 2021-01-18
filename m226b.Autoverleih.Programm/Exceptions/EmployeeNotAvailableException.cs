using System;
using System.Collections.Generic;
using System.Text;

namespace m226b.Autoverleih.Programm.Exceptions
{
    public class EmployeeNotAvailableException : Exception
    {
        public EmployeeNotAvailableException()
        {
        }

        public EmployeeNotAvailableException(string message) : base(message)
        {
        }

        public EmployeeNotAvailableException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
