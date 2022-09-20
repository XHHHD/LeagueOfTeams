using LeagueOfTeamsDataAccess.Entities;

namespace LeagueOfTeamsDataAccess.Repositories
{
    public class PositionNameRepository
    {
        AppContext _db;
        public PositionNameRepository()
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
