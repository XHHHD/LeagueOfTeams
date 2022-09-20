using LeagueOfTeamsDataAccess.Entities;
using LeagueOfTeamsDataAccess.Repositories;

namespace LeagueOfTeamsDataAccess.Interfaces
{
    public interface IMember
    {
        public void AddMember(Member member);
        public void RemoveMember(Member member);
        public Member GetMemberById(int id);
        public Member GetMemberByName(string name);
        public List<Member> GetAllMembers();
        public List<Member> GetMembersByTeamId(int id);
        public List<Member> GetMembersByTeamName(string teamName);
        public List<Member> GetMembersByPosition(string positionName);
    }
}
