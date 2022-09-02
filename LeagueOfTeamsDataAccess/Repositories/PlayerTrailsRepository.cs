using LeagueOfTeamsDataAccess.Entities;

namespace LeagueOfTeamsDataAccess.Repositories
{
    public class PlayerTrailsRepository
    {
        AppContext _db;
        public PlayerTrailsRepository()
        {
            string dbConnectionString =
                "Server=(localdb)\\mssqllocaldb;Initial Catalog=MyDB;Integrated Security=True;";
            _db = new AppContext(dbConnectionString);
        }
        public List<PlayerTrail> GetAllPlayerTrails()
        {
            return _db.PlayerTrails.ToList();
        }
        public PlayerTrail GetPlayerTrail(int trailID)
        {
            return _db.PlayerTrails.ElementAtOrDefault(trailID);
        }
    }
}
