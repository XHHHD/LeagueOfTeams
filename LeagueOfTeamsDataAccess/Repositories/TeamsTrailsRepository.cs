using LeagueOfTeamsDataAccess.Entities;

namespace LeagueOfTeamsDataAccess.Repositories
{
    public class TeamsTrailsRepository
    {
        AppContext _db;
        public TeamsTrailsRepository()
        {
            string dbConnectionString =
                "Server=(localdb)\\mssqllocaldb;Initial Catalog=MyDB;Integrated Security=True;";
            _db = new AppContext(dbConnectionString);
        }
        public List<TeamTrail> GetAllPlayerTrails()
        {
            return _db.PlayerTrails.ToList();
        }
        public TeamTrail GetPlayerTrail(int trailID)
        {
            return _db.PlayerTrails.ElementAtOrDefault(trailID);
        }
    }
}
