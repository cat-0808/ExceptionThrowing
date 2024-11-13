using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionThrowing
{
    class NumberFormatException : Exception
    {
        public NumberFormatException(string qty) : base(qty)
        { 

        }
    }
}
