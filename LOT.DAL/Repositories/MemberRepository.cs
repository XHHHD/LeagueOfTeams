using LOT.DAL.Entities;
using LOT.DAL.Exceptions;
using LOT.DAL.Interfaces;

namespace LOT.DAL.Repositories
{
    public class MemberRepository : IMemberRepository
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
        public void RemoveMember(int id)
        {
            var memberForRemoving = GetMemberById(id);
            if (memberForRemoving != null)
            {
                _db.Members.Remove(memberForRemoving);
                _db.SaveChanges();
            }
            else
                throw new MemberDataException("Didn`t find member for removing!");
        }

        /// <summary>
        /// Update or add member in database.
        /// </summary>
        /// <param name="member"></param>
        public void UpdateMember(Member member)
        {
            if (GetMemberById(member.Id) is null)
                throw new MemberDataException("Didn`t find member entity in database!");
            else
            {
                _db.Members.Update(member);
                _db.SaveChanges();
            }
        }

        public void SaveMember(Member savingMember)
        {
            var entityFromDB = GetMemberById(savingMember.Id);
            if (entityFromDB is null)
                throw new MemberDataException("Didn`t find member entity in database!");
            else
            {
                entityFromDB = savingMember;
                _db.SaveChanges();
                savingMember.Id = entityFromDB.Id;
            }
        }

        /// <summary>
        /// Searcing in database entity`s of member and position.
        /// Add position entity on member list of position`s. Return refreshed member model.
        /// </summary>
        /// <param name="memberId">Member entity ID.</param>
        /// <param name="position">Position entity ID.</param>
        /// <returns>Actualized member model.</returns>
        /// <exception cref="MemberDataException"></exception>
        public Member AddPositionToTheMember(int memberId, Position position)
        {
            if(position is null)
                throw new MemberDataException("Position can`t be added, coz position is NULL!");
            var member = GetMemberById(memberId);
            if (member is null)
                throw new MemberDataException("Didn`t find currently member in database!");
            else
            {
                member.Positions.Add(position);
                _db.SaveChanges();
            }
            return member;
        }

        /// <summary>
        /// Get from database all created members in game.
        /// </summary>
        /// <returns>Enumerable members</returns>
        public IEnumerable<Member> GetAll() => _db.Members;


        /// <summary>
        /// Get list members names from database.
        /// </summary>
        /// <returns>List members names.</returns>
        public List<string> GetAllNames() => _db.Members.Select(m => m.Name).ToList();

        /// <summary>
        /// Get member`s entity`s of currently team by team ID.
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns>List of member`s of NULL.</returns>
        public List<Member> GetMembersByTeamId(int teamId) =>
            _db.Teams.FirstOrDefault(t => t.Id == teamId).Members;

        /// <summary>
        /// Get member`s entity`s of currently team by team name.
        /// </summary>
        /// <param name="teamName"></param>
        /// <returns>List of member`s of NULL.</returns>
        public List<Member> GetMembersByTeamName(string teamName) =>
            _db.Teams.FirstOrDefault(t => t.Name == teamName).Members;



        /// <summary>
        /// Need to correct this method.
        /// </summary>
        /// <param name="positionName"></param>
        /// <returns></returns>
        public IEnumerable<Member> GetMembersByPosition(PositionsNamesDAL positionName) =>
            _db.Members
            .Where(m => m.Positions.FirstOrDefault(p => p.Name == positionName).Name == positionName);

        /// <summary>
        /// Get from database currently member by member ID.
        /// </summary>
        /// <param name="memberID">Searching member id (int)</param>
        /// <returns>Member entity or NULL!</returns>
        public Member GetMemberById(int memberID) =>
            _db.Members.FirstOrDefault(m => m.Id == memberID);

        public Member GetMemberByName(string name) =>
            _db.Members.FirstOrDefault(m => m.Name == name);

        public Member GetLast() =>
            _db.Members.OrderBy(id => id == id).LastOrDefault();
    }
}
