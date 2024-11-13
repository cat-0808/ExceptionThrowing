using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionThrowing
{
    class StringFormatException : Exception
    {
        public StringFormatException(string name) : base(name){ }
    }
}
