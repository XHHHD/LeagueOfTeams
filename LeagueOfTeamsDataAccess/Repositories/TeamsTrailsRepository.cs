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
        public void AddNewTrail(TeamTrail newTrail)
        {
            _db.Add(newTrail);
            _db.SaveChanges();
        }
        public void RemoveTrail(TeamTrail trail)
        {
            _db.Remove(trail);
            _db.SaveChanges();
        }
        public List<TeamTrail> GetAllTrails() => _db.TeamTrails.ToList();
        public TeamTrail GetCurrentTrail(int trailID) => _db.TeamTrails.ElementAtOrDefault(trailID);
    }
}
