namespace LeagueOfTeamsDataAccess.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string MemberNick { get; set; }
        public byte MemberAge { get; set; }
        public int MemberEnergy { get; set; }
        public int MemberMaxEnergy { get; set; }
        public uint MemberMainExpiriance { get; set; }
        public byte MemberFreeMainSkillPoints { get; set; }
        public Positions CurrentlyMemberMainPositionId { get; set; }
        public List<Positions> PositionsId { get; set; }
        public List<MemberTrail>? MemberTrailsList { get; set; }
        public Positions Positions { get; set; }
        public MemberTrail MemberTrail { get; set; }
        public DateTime MemberCreationDate { get; set; }
    }
}
