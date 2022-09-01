namespace LeagueOfTeamsDataAccess.Entities
{
    internal class Member
    {
        internal int Id { get; set; }
        internal string _memberNick { get; set; }
        internal byte _memberAge { get; set; }
        internal int _memberEnergy { get; set; }
        internal int _memberMaxEnergy { get; set; }
        internal uint _memberMainExpiriance { get; set; }
        internal byte _memberFreeMainSkillPoints { get; set; }
        internal List<Position> _memberPositions { get; set; }
        internal Position _currentlyMemberMainPosition { get; set; }
        internal List<MemberTrail> _memberTrailsList { get; set; }
        internal DateTime memberCreationDate { get; set; }
    }
}
