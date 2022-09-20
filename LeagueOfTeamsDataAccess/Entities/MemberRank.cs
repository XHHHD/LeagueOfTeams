using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfTeamsDataAccess.Entities
{
    internal class MemberRank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Member Members { get; set; }
    }
}
