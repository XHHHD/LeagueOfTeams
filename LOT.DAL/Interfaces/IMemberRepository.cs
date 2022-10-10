using LOT.DAL.Entities;
using LOT.DAL.Repositories;

namespace LOT.DAL.Interfaces
{
    public interface IMemberRepository
    {
        public void AddMember(Member member);
        public void RemoveMember(Member member);
        public Member GetMemberById(int id);
        public Member GetMemberByName(string name);
        public IEnumerable<Member> GetAllMembers();
        public IEnumerable<Member> GetMembersByTeam(int id);
        public IEnumerable<Member> GetMembersByTeamName(string teamName);
        public IEnumerable<Member> GetMembersByPosition(string positionName);
    }
}
