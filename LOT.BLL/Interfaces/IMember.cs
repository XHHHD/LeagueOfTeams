using LOT.BLL.Models.Teams;
using System.Collections.Generic;
using System;
using LOT.BLL.Models.Ranks;
using LOT.BLL.Models.Trails;

namespace LOT.BLL.Interfaces
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
        public byte SkillPoints { get; set; }
        public int RankPoints { get; set; }
        
        //PROXY KEY's
        public MemberRankModel MemberRank { get; set; }
        public TeamModel? Team { get; set; }
        public MemberTrailModel? MemberTrail { get; set; }
    }
}
