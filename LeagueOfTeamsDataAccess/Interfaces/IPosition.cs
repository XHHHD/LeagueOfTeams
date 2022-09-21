using LeagueOfTeamsDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfTeamsDataAccess.Interfaces
{
    internal interface IPosition
    {
        public void AddPosition(Position position);
        public void RemovePosition(Position position);
        public Position GetPositionById(int id);
        public List<Position> GetAllPositions();
        public List<Position> GetPositionsByMemberName(string memberName);
        public List<Position> GetPositionsByName(string name);
    }
}
