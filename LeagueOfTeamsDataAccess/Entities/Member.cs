namespace LeagueOfTeamsDataAccess.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public int Energy { get; set; }
        public int MaxEnergy { get; set; }
        public uint Expiriance { get; set; }
        public byte FreeSkillPoints { get; set; }
        public List<Position> Positions { get; set; }
        public Position MainPosition { get; set; }
        public List<MemberTrail>? MemberTrails { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastChanges { get; set; }
    }
}
