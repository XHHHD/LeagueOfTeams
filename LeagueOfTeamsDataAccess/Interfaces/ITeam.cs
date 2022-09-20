using LeagueOfTeamsDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfTeamsDataAccess.Interfaces
{
    public interface ITeam
    {
        public void AddTeam(Team team);
        public void RemoveTeam(Team team);
        public Member GetTeamById(int id);
        public Member GetTeamByName(string name);
        public Member GetTeamByMemberId(int id);
        public Member GetTeamByMemberName(string teamName);
        public List<Member> GetAllTeams();
        public List<Member> GetTeamsByRank(int Rank);
    }
}
