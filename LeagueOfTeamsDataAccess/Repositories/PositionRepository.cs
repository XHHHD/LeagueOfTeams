using LeagueOfTeamsDataAccess.Entities;
using LeagueOfTeamsDataAccess.Interfaces;

namespace LeagueOfTeamsDataAccess.Repositories
{
    public class PositionRepository : IPosition
    {
        AppContext _db;
        public PositionRepository()
        {
            string dbConnectionString =
                "Server=(localdb)\\mssqllocaldb;Initial Catalog=MyDB;Integrated Security=True;";
            _db = new AppContext(dbConnectionString);
        }

        public void AddPosition(Position position)
        {
            _db.Positions.Add(position);
            _db.SaveChanges();
        }
        public void RemovePosition(Position position)
        {
            _db.Positions.Remove(position);
            _db.SaveChanges();
        }

        public List<Position> GetAllPositions()
        {
            throw new NotImplementedException();
        }

        public Position GetPositionById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Position> GetPositionsByMemberName(string memberName)
        {
            throw new NotImplementedException();
        }

        public List<Position> GetPositionsByName(string name)
        {
            throw new NotImplementedException();
        }

    }
}
