using LOT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOT.DAL.Interfaces
{
    internal interface IPositionRepository
    {
        public void AddPosition(Position position);
        public void RemovePosition(Position position);
        public Position GetPositionById(int id);
        public List<Position> GetAllPositions();
        public List<Position> GetPositionsByMemberName(string memberName);
        public List<Position> GetPositionsByName(string name);
    }
}
