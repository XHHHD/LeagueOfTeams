using LOT.DAL.Entities;
using LOT.DAL.Exceptions;
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

        /// <summary>
        /// Add new position entity in database.
        /// </summary>
        /// <param name="position">Adding posotion entity.</param>
        /// <exception cref="PositionDataException"></exception>
        public void AddPosition(Position position)
        {
            if (position is null)
                throw new PositionDataException("Adding position is NULL!");
            else
            {
                _db.Positions.Add(position);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// Remove current position by ID from database.
        /// </summary>
        /// <param name="id">ID of position, with must be removed.</param>
        /// <exception cref="PositionDataException"></exception>
        public void RemovePosition(int id)
        {
            var position = _db.Positions.Find(id);
            if (position is null)
                throw new PositionDataException("Attempt to remove a missing item.");
            else
            {
                _db.Positions.Remove(position);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// Remove current position from database.
        /// </summary>
        /// <param name="position">Position object, with must be removed.</param>
        /// <exception cref="PositionDataException"></exception>
        public void RemovePosition(Position position)
        {
            if (position is null || _db.Positions.Find(position) is null)
                throw new PositionDataException("Attempt to remove a missing item.");
            else
            {
                _db.Positions.Remove(position);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// Update current position in database.
        /// </summary>
        /// <param name="position">Position object, with must be updated.</param>
        /// <exception cref="PositionDataException"></exception>
        public void UpdatePosition(Position position)
        {
            if (position is null)
                throw new PositionDataException("Position entity is NULL!");
            else
                _db.Positions.Update(position);
        }

        public List<Position> GetAllPositions() => _db.Positions.ToList();

        public Position GetPositionById(int id) => _db.Positions.FirstOrDefault(p => p.Id == id);

        public List<Position> GetPositionsByMemberName(string memberName) => _db.Positions.Where(p => p.Member.Name == memberName).ToList();

        public IEnumerable<Position> GetPositionsByName(PositionsNamesDAL name) => _db.Positions.Where(p => p.Name == name);

    }
}
