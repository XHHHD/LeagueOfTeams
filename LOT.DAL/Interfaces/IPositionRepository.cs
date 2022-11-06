using LOT.DAL.Entities;

namespace LOT.DAL.Interfaces
{
    internal interface IPositionRepository
    {
        public void AddPosition(Position position);
        public void RemovePosition(Position position);
        public Position GetPositionById(int id);
        public List<Position> GetAllPositions();
        public List<Position> GetPositionsByMemberName(string memberName);
        public IEnumerable<Position> GetPositionsByName(PositionsNamesDAL name);
    }
}
