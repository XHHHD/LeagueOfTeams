using LOT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOT.DAL.Interfaces
{
    public interface ITeamReposytory
    {
        public void AddTeam(ITeam team);
        public void RemoveTeam(ITeam team);
        public ITeam GetTeamById(int id);
        public ITeam GetTeamByName(string name);
        public ITeam GetTeamByMemberId(int id);
        public ITeam GetTeamByMemberName(string teamName);
        public List<ITeam> GetAllTeams();
        public List<ITeam> GetTeamsByRank(int Rank);
    }
}
