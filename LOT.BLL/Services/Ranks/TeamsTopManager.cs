using AutoMapper;
using LOT.BLL.Models.Teams;
using LOT.DAL.Repositories;

namespace LOT.BLL.Services.Ranks
{
    //This is the class, that will be hendle to the data and show
    //different views for teams top, team sort and team searching.
    internal static class TeamsTopManager
    {
        private static readonly IMapper mapper;
        private static readonly TeamRepository repository = new();

        /// <summary>
        /// Get collection of teams with highest rank.
        /// </summary>
        /// <returns>Teams list or EMPTY teams list.</returns>
        public static List<TeamModel> GetTeamsTop()
        {
            var allTeams = repository.GetAll();
            if (allTeams == null)
                return new List<TeamModel>();
            else
            {
                var teams = mapper.Map<List<TeamModel>>(allTeams);
                teams.OrderBy(x => x.RankPoints).ToList();
                return teams;
            }
        }

        /// <summary>
        /// Get currently count collection of teams with highest rank.
        /// Careful - list can be smaller than expected size!
        /// </summary>
        /// <param name="topCount">Size of collection.</param>
        /// <returns>Teams list or EMPTY teams list.</returns>
        public static List<TeamModel> GetTeamsTop(int topCount)
        {
            var teams = GetTeamsTop();
            teams.RemoveRange(topCount, teams.Count);
            return teams;
        }
    }
}
