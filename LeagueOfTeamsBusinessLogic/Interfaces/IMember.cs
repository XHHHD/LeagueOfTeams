using LeagueOfTeamsBusinessLogic.Models.Members;
using LeagueOfTeamsBusinessLogic.Models.Teams;
using System.Collections.Generic;
using System;

namespace LeagueOfTeamsBusinessLogic.Interfaces
{
    internal interface IMember
    {
        public DateTime CreationDate { get; }
        public DateTime LastChanges { get; set; }
        public int Id { get; }
        public string Name { get; }
        public byte Age { get; set; }
        public int Energy { get; set; }
        public int MaxEnergy { get; set; }
        public uint Expiriance { get; set; }
        public byte FreeSkillPoints { get; set; }
        public int RankPoints { get; set; }
        
        //PROXY KEY's
        public MemberRank MemberRank { get; set; }
        public Team? Team { get; set; }
        public MemberTrail? MemberTrail { get; set; }
    }
}
