using LOT.DAL.Interfaces;

namespace LOT.DAL.Entities
{
    public class Member : IMember
    {
        //BASIC STATS
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public int Energy { get; set; }
        public int MaxEnergy { get; set; }
        public uint Expiriance { get; set; }
        public byte SkillPoints { get; set; }
        public int RankPoints { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastChanges { get; set; }


        //POXY KEYS
        public MemberRank? MemberRank { get; set; }
        public Team? Team { get; set; }
        public MemberTrail? MemberTrail { get; set; }


        //PROXY STATS
        public int? TeamId { get; set; }
        public int? MemberRankId { get; set; }
        public int? MemberTrailId { get; set; }
        public List<Position> Positions { get; set; }
    }
}
