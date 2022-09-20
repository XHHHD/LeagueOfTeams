namespace LeagueOfTeamsBusinessLogic.Models.Teams
{
    internal class TeamTrail
    {
        //There will be trails of player, wich can be added to the team.
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
