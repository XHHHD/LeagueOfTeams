using LOT.DAL.Entities;
using LOT.DAL.Interfaces;

namespace LOT.DAL.Repositories
{
    public class PositionRepository : IPositionRepository
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

        public List<Position> GetAllPositions() => _db.Positions.ToList();

        public Position GetPositionById(int id) => _db.Positions.FirstOrDefault(p => p.Id == id);

        public List<Position> GetPositionsByMemberName(string memberName) => _db.Positions.Where(p => p.Member.Name == memberName).ToList();

        public List<Position> GetPositionsByName(string name) => _db.Positions.Where(p => p.Name == name).ToList();

    }
}
