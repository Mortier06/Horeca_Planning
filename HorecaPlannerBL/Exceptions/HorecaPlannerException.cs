using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorecaPlannerBL.Exceptions
{
    public class HorecaPlannerException : Exception
    {
        public HorecaPlannerException()
        {
        }

        public HorecaPlannerException(string? message) : base(message)
        {
        }

        public HorecaPlannerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
