namespace LeagueOfTeamsDataAccess.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string _memberNick { get; set; }
        public byte _memberAge { get; set; }
        public int _memberEnergy { get; set; }
        public int _memberMaxEnergy { get; set; }
        public uint _memberMainExpiriance { get; set; }
        public byte _memberFreeMainSkillPoints { get; set; }
        public Position _currentlyMemberMainPosition { get; set; }
        public List<Position> _memberPositions { get; set; }
        public List<MemberTrail>? _memberTrailsList { get; set; }
        public DateTime memberCreationDate { get; set; }
    }
}
