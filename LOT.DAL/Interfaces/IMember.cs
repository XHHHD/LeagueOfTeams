namespace LOT.DAL.Interfaces
{
    public interface IMember
    {
        public int Id { get;}
        public string Name { get; set; }
        public byte Age { get; set; }
        public int Power { get; set; }
        public int Energy { get; set; }
        public int MaxEnergy { get; set; }
        public int MentalPower { get; set; }
        public int MentalResistance { get; set; }
        public int Teamplay { get; set; }
        public uint Expiriance { get; set; }
        public uint Level { get; }
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
