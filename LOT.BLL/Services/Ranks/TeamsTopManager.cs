using LOT.BLL.Models.Teams;

namespace LOT.BLL.Services.Ranks
{
    //This is the class, that will be hendle to the data and show
    //different views for teams top, team sort and team searching.
    internal static class TeamsTopManager
    {
        public static List<TeamModel> GetTeamsTop() => new List<TeamModel>();
        public static TeamModel GetCurrentTeam(int teamID) => null;
        public static bool IsThisNamespaceFree(string checkedTeamName) => true;
    }
}
