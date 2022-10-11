using LOT.DAL.Entities;
using LOT.DAL.Exceptions;

namespace LOT.DAL.Repositories
{
    public class TeamRepository
    {
        AppContext _db;
        public TeamRepository()
        {
            string dbConnectionString =
                "Server=(localdb)\\mssqllocaldb;Initial Catalog=MyDB;Integrated Security=True;";
            _db = new AppContext(dbConnectionString);
        }

        /// <summary>
        /// Adding new team in data base.
        /// </summary>
        /// <param name="team">The entity Team, wich must be added.</param>
        public void Add(Team team)
        {
            _db.Teams.Add(team);
            _db.SaveChanges();
        }

        /// <summary>
        /// Update currently team in data base.
        /// </summary>
        /// <param name="team">The entity Team, wich must be updated.</param>
        public void UpdateTeam(Team team)
        {
            if(GetTeam(team.Id) != null)
                _db.Update(team);
            else
                Add(team);
        }

        /// <summary>
        /// Remove currently team from data base.
        /// </summary>
        /// <param name="id">Id of the team, wich must be removed.</param>
        public void RemoveTeam(int id)
        {
            var teamToRemove = _db.Teams.FirstOrDefault(x => x.Id == id);
            if (teamToRemove != null)
            {
                _db.Teams.Remove(teamToRemove);
                _db.SaveChanges();
            }
            else
                throw new TeamDataException("Didn`t find currently team in data base, to remove.");
        }

        /// <summary>
        /// Remove currently team from data base.
        /// </summary>
        /// <param name="id">Id of the team, wich must be removed.</param>
        /// <exception cref="TeamDataException"></exception>
        public async void RemoveAsync(int id)
        {
            var teamToRemove = await _db.Teams.FindAsync(id);
            if (teamToRemove != null)
            {
                await Task.Run(() => _db.Teams.Remove(teamToRemove));
                _db.SaveChanges();
            }
            else
                throw new TeamDataException("Didn`t find currently team in data base, to remove.");
        }

        /// <summary>
        /// Get all teams from data base.
        /// </summary>
        /// <returns>Collection of the Teams entities.</returns>
        public IEnumerable<Team> GetAll() => _db.Teams;

        /// <summary>
        /// Get from data base team with currently Id.
        /// </summary>
        /// <param name="id">Id of the team you lookig for.</param>
        /// <returns>Entity Team.</returns>
        /// <exception cref="TeamDataException"></exception>
        public Team GetTeam(int id)
        {
            var team = _db.Teams.FirstOrDefault(t => t.Id == id);
            if (team != null)
                return team;
            else
                throw new TeamDataException("Didn`t find currently team.");
        }

        /// <summary>
        /// Find members from currently team.
        /// </summary>
        /// <param name="id">Id of the team, whose members are to be found.</param>
        /// <returns>Collection of the Members entities.</returns>
        public IEnumerable<Member> GetTeamMembers(int id) => _db.Members.Where(m => m.TeamId == id);
    }
}
