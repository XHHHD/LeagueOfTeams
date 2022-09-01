using LeagueOfTeamsDataAccess.Entities;

namespace LeagueOfTeamsDataAccess.Repositories
{
    internal class PositionRepository
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
    }
}
