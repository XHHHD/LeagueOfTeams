using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfTeamsBusinessLogic.Exceptions
{
    internal class TeamRegistrationException : Exception
    {
        public TeamRegistrationException() : base() { }
        public TeamRegistrationException(string exceptionMessage) : base(exceptionMessage) { }
    }
}
