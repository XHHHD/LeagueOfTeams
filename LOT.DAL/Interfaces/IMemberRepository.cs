using LOT.DAL.Entities;

namespace LOT.DAL.Interfaces
{
    public interface IMemberRepository
    {
        public void AddMember(Member member);
        public void RemoveMember(int id);
        public Member GetMemberById(int id);
        public Member GetMemberByName(string name);
        public IEnumerable<Member> GetAll();
        public List<Member> GetMembersByTeamId(int id);
        public List<Member> GetMembersByTeamName(string teamName);
        public IEnumerable<Member> GetMembersByPosition(PositionsNamesDAL positionName);
    }
}
