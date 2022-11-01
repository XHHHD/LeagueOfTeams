using LOT.DAL.Entities;
using LOT.DAL.Exceptions;

namespace LOT.DAL.Repositories
{
    public class TeamRankRepository
    {
        AppContext _db;
        public TeamRankRepository()
        {
            string dbConnectionString = "Server=(localdb)\\mssqllocaldb;Initial Catalog=MyDB;Integrated Security=True;";
            _db = new AppContext(dbConnectionString);
        }

        /// <summary>
        /// Add new team rank.
        /// </summary>
        /// <param name="newRank">TeamRank entity</param>
        public void AddRank(TeamRank newRank)
        {
            if (GetRank(newRank.Name) == null)
            {
                _db.TeamRanks.Add(newRank);
                _db.SaveChanges();
            }
            else
                throw new TeamDataException("Currently team rank is already present in database!");
        }

        /// <summary>
        /// Remove team rank from database.
        /// </summary>
        /// <param name="rank">Id of the team rank, wich must be removed.</param>
        public void Remove(int id)
        {
            var rankToRemove = _db.TeamRanks.FirstOrDefault(x => x.Id == id);
            if (rankToRemove != null)
            {
                _db.TeamRanks.Remove(rankToRemove);
                _db.SaveChanges();
            }
            else
                throw new TeamDataException("Can`t find currently team rank entity in database for removing.");
        }

        /// <summary>
        /// Update current team rank in database.
        /// </summary>
        /// <param name="teamRank">Team rank wich must be updated.</param>
        /// <exception cref="TeamDataException"></exception>
        public void Update(TeamRank teamRank)
        {
            if (teamRank != null)
                _db.TeamRanks.Update(teamRank);
            else
                throw new TeamDataException("Team rank is NULL!");
        }
        
        /// <summary>
        /// Get currently team rank.
        /// </summary>
        /// <param name="id">Team rank ID</param>
        /// <returns></returns>
        public TeamRank GetRank(int id) => _db.TeamRanks.FirstOrDefault(x => x.Id == id);

        /// <summary>
        /// Get currently team rank.
        /// </summary>
        /// <param name="name">Team rank name</param>
        /// <returns></returns>
        public TeamRank GetRank(string name) => _db.TeamRanks.FirstOrDefault(x => x.Name == name);

        public IEnumerable<TeamRank> GetAll() => _db.TeamRanks;
    }
}
