namespace LeagueOfTeamsDataAccess.Entities
{
    public class TeamTrail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
