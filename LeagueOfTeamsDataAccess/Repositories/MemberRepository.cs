using LeagueOfTeamsDataAccess.Entities;
using LeagueOfTeamsDataAccess.Interfaces;

namespace LeagueOfTeamsDataAccess.Repositories
{
    public class MemberRepository : IMember
    {
        AppContext _db;
        public MemberRepository()
        {
            string dbConnectionString =
                "Server=(localdb)\\mssqllocaldb;Initial Catalog=MyDB;Integrated Security=True;";
            _db = new AppContext(dbConnectionString);
        }
        /// <summary>
        /// Save in database new member object.
        /// </summary>
        /// <param name="member">Created member</param>
        public void AddMember(Member member)
        {
            _db.Members.Add(member);
            _db.SaveChanges();
        }
        /// <summary>
        /// Delete from database currently member.
        /// </summary>
        /// <param name="member">Member object, that must be deleted.</param>
        public void RemoveMember(Member member)
        {
            _db.Members.Remove(member);
            _db.SaveChanges();
        }

        /// <summary>
        /// Get from database all created members in game.
        /// </summary>
        /// <returns>List of members</returns>
        public List<Member> GetAllMembers() => _db.Members.ToList();
        /// <summary>
        /// Get from database currently member by member ID.
        /// </summary>
        /// <param name="memberID">Searching member id (int)</param>
        /// <returns>Member object</returns>
        public Member GetMemberById(int memberID) => _db.Members.ElementAtOrDefault(memberID);
        public Member GetMemberByNick(string memberNick) => _db.Members.Find(memberNick);

        public Member GetMemberByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Member> GetMembersByTeamId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Member> GetMembersByTeamName(string teamName)
        {
            throw new NotImplementedException();
        }

        public List<Member> GetMembersByPosition(string positionName)
        {
            throw new NotImplementedException();
        }
    }
}
