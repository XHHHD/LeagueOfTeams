using LeagueOfTeamsDataAccess.Entities;
using LeagueOfTeamsDataAccess.Repositories;

namespace LeagueOfTeamsDataAccess.Interfaces
{
    public interface IMember
    {
        public List<Member> GetAllMembers();

    }
}
