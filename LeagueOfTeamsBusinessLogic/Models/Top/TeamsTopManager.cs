using LeagueOfTeamsBusinessLogic.Models.Teams;

namespace LeagueOfTeamsBusinessLogic.Models.Top
{
    //This is the class, that will be hendle to the data and show
    //different views for teams top, team sort and team searching.
    internal static class TeamsTopManager
    {
        public static List<Team> GetTeamsTop() => new List<Team>();
        public static Team GetCurrentTeam(int teamID) => null;
        public static bool IsThisNamespaceFree(string checkedTeamName) => true;
    }
}
