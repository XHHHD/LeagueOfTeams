using LeagueOfTeamsDataAccess.Entities;

namespace LeagueOfTeamsDataAccess.Repositories
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
        public List<Team> GetAllTeams()
        {
            return _db.Teams.ToList();
        }
        public void AddTeam(Team team)
        {
            _db.Teams.Add(team);
            _db.SaveChanges();
        }
        public void RemuveTeam(Team team)
        {
            _db.Teams.Remove(team);
            _db.SaveChanges();
        }
    }
}
