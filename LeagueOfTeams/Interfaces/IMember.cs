using LeagueOfTeamsModel.Models.Member;
using System;

namespace LeagueOfTeamsModel.Interfaces
{
    internal interface IMember
    {
        public uint MemberID { get; }
        public string MemberName { get; }
        public MemberPosition[] MemberPositions { get; set; }
        public byte MemberAge { get; }
        public int MemberEnergy { get; set; }
        public uint MemberMainExpiriance { get; set; }
        public byte MemberFreeMainSkillPoints { get; set; }
    }
}
