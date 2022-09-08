using LeagueOfTeamsDataAccess.Entities;

namespace LeagueOfTeamsDataAccess.Repositories
{
    public class PositionsNamesRepository
    {
        AppContext _db;
        public PositionsNamesRepository()
        {
            string dbConnectionString =
                "Server=(localdb)\\mssqllocaldb;Initial Catalog=MyDB;Integrated Security=True;";
            _db = new AppContext(dbConnectionString);
        }
        public List<PositionsNames> GetAllPositions()
        {
            return _db.PositionsNames.ToList();
        }
        public PositionsNames GetCurrentlyPosition(int posotionIndex)
        {
            return _db.PositionsNames.ToArray()[posotionIndex];
        }
    }
}
