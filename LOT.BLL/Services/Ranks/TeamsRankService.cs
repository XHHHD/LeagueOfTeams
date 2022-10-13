using AutoMapper;
using LOT.BLL.Exceptions;
using LOT.BLL.Models.Ranks;
using LOT.BLL.Models.Teams;
using LOT.DAL.Entities;
using LOT.DAL.Repositories;

namespace LOT.BLL.Services.Ranks
{
    //This is the class, that will be hendle to the data and show
    //different views for teams top, team sort and team searching.
    internal static class TeamsRankService
    {
        private static readonly IMapper mapper;
        private static readonly TeamRankRepository rankRepo = new();
        private static readonly TeamRepository teamRepo = new();

        public static void Add(TeamRankModel rankModel) => rankRepo.Add(mapper.Map<TeamRank>(rankModel));
        public static void Remove(TeamRankModel rankModel) => rankRepo.Remove(rankModel.Id);
        public static void Update(TeamRankModel rankModel) => rankRepo.Update(mapper.Map<TeamRank>(rankModel));

        /// <summary>
        /// Get Team rank model by ID.
        /// </summary>
        /// <param name="id">Team rank ID.</param>
        /// <returns>TeamRankModel.</returns>
        /// <exception cref="TeamRankServicesException"></exception>
        public static TeamRankModel GetRank(int id)
        {
            var entity = rankRepo.GetRank(id);
            if (entity is null)
                throw new TeamRankServicesException("There is no team rank with this ID in database!");
            else
                return mapper.Map<TeamRankModel>(entity);
        }

        /// <summary>
        /// Get Team rank model by name.
        /// </summary>
        /// <param name="name">Team rank name.</param>
        /// <returns>TeamRankModel.</returns>
        /// <exception cref="TeamRankServicesException"></exception>
        public static TeamRankModel GetRank(string name)
        {
            var entity = rankRepo.GetRank(name);
            if (entity is null)
                throw new TeamRankServicesException("There is no team rank with this name in database!");
            else
                return mapper.Map<TeamRankModel>(entity);
        }

        /// <summary>
        /// Get all Team ranks from database.
        /// </summary>
        /// <returns>TeamRanks collection.</returns>
        /// <exception cref="TeamRankServicesException"></exception>
        public static IEnumerable<TeamRankModel> GetAllRanks()
        {
            var allRanks = rankRepo.GetAll();
            if (allRanks != null)
            {
                var rankModels = mapper.Map<IEnumerable<TeamRankModel>>(allRanks);
                return rankModels;
            }
            else
                throw new TeamRankServicesException("TeamRanks data is empty!");
        }

        /// <summary>
        /// Get collection of teams with highest rank.
        /// </summary>
        /// <returns>Teams list or EMPTY teams list.</returns>
        public static List<TeamModel> GetTeamsTop()
        {
            var allTeams = teamRepo.GetAll();
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
