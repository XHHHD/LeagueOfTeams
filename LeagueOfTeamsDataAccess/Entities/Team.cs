namespace LeagueOfTeamsDataAccess.Entities
{
    public class Team
    {
        //BASIC STATS
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public uint Expiriance { get; set; }
        public int Energy { get; set; }
        public int Power { get; set; }
        public int Health { get; set; }
        public int Teamplay { get; set; }
        public int LeaguePoints { get; set; }
        public int RankId { get; set; }


        //PROXY STATS
        public TeamRank TeamRank { get; set; }
        public TeamTrail? TeamTrail { get; set; }
        public List<Member> Members { get; set; }


        //PROXY KEYS
        public int TeamRankId { get; set; }
        public int TeamTrailId { get; set; }
    }
}
