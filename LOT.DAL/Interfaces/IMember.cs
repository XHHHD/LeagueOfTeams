namespace LOT.DAL.Interfaces
{
    public interface IMember
    {
        public int Id { get;}
        public string Name { get; set; }
        public byte Age { get; set; }
        public int Energy { get; set; }
        public int MaxEnergy { get; set; }
        public uint Expiriance { get; set; }
        public byte SkillPoints { get; set; }
        public int RankPoints { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastChanges { get; set; }

        //PROXY STATS
        public int? TeamId { get; set; }
        public int? MemberRankId { get; set; }
        public int? MemberTrailId { get; set; }
    }
}
