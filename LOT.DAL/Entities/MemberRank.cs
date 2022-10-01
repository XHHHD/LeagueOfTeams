using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOT.DAL.Entities
{
    public class MemberRank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Member> Members { get; set; }
    }
}
