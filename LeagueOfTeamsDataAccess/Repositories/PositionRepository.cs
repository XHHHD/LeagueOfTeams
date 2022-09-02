using LeagueOfTeamsDataAccess.Entities;

namespace LeagueOfTeamsDataAccess.Repositories
{
    public class PositionRepository
    {
        AppContext _db;
        public PositionRepository()
        {
            string dbConnectionString =
                "Server=(localdb)\\mssqllocaldb;Initial Catalog=MyDB;Integrated Security=True;";
            _db = new AppContext(dbConnectionString);
        }
        public List<Position> GetAllPositions()
        {
            return _db.Positions.ToList();
        }
        public Position GetCurrentlyPosition(int posotionIndex)
        {
            return _db.Positions.ToArray()[posotionIndex];
        }
    }
}
