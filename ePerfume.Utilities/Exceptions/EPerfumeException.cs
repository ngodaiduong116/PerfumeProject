using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePerfume.Utilities.Exceptions
{
    public class EPerfumeException : Exception
    {
        public EPerfumeException()
        {
        }

        public EPerfumeException(string message) : base(message)
        {
        }

        public EPerfumeException(string message, Exception inner) : base(message, inner)
        {
        }

    }
}
