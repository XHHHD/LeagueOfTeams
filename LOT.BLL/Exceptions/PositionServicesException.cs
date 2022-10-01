using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOT.BLL.Exceptions
{
    internal class PositionServicesException : Exception
    {
        public PositionServicesException() : base() { }
        public PositionServicesException(string exceptionMessage) : base(exceptionMessage) { }
    }
}
