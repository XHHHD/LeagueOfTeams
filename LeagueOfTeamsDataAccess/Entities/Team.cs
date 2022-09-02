namespace LeagueOfTeamsDataAccess.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string _teamName { get; set; }
        public string _teamShortName { get; set; }
        public string _teamDescription { get; set; }
        public uint _playerExpiriance { get; set; }
        public int _teamEnergy { get; set; }
        public int _teamPower { get; set; }
        public int _teamHealth { get; set; }
        public int _teamCooperation { get; set; }
        public List<Member> _members { get; set; }
        public List<PlayerTrail> _playerTrails { get; set; }
    }
}
