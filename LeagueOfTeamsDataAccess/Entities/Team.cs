namespace LeagueOfTeamsDataAccess.Entities
{
    internal class Team
    {
        private int Id { get; set; }
        private string _teamName { get; set; }
        private string _teamShortName { get; set; }
        private string _teamDescription { get; set; }
        private uint _playerExpiriance { get; set; }
        private int _teamEnergy { get; set; }
        private int _teamPower { get; set; }
        private int _teamHealth { get; set; }
        private int _teamCooperation { get; set; }
        private List<Member> _members { get; set; }
        private List<PlayerTrail> _playerTrails { get; set; }
    }
}
