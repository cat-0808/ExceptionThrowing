using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionThrowing
{
    class CurrencyFormatException : Exception
    {
        public CurrencyFormatException(string price) : base(price) { }
    }
}
