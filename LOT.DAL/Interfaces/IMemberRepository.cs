using LOT.DAL.Entities;

namespace LOT.DAL.Interfaces
{
    public interface IMemberRepository
    {
        public void AddMember(Member member);
        public void RemoveMember(Member member);
        public Member GetMemberById(int id);
        public Member GetMemberByName(string name);
        public IEnumerable<Member> GetAll();
        public IEnumerable<Member> GetMembersByTeam(int id);
        public IEnumerable<Member> GetMembersByTeamName(string teamName);
        public IEnumerable<Member> GetMembersByPosition(PositionsNames positionName);
    }
}
