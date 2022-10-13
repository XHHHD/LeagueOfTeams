using LOT.DAL.Entities;
using LOT.DAL.Exceptions;

namespace LOT.DAL.Repositories
{
    public class MemberRankRepository
    {
        AppContext _db;
        public MemberRankRepository()
        {
            string dbConnectionString =
                "Server=(localdb)\\mssqllocaldb;Initial Catalog=MyDB;Integrated Security=True;";
            _db = new AppContext(dbConnectionString);
        }

        /// <summary>
        /// Add new member rank.
        /// </summary>
        /// <param name="newRank">MemberRank entity</param>
        /// <exception cref="MemberDataException"></exception>
        public void Add(MemberRank newRank)
        {
            if (_db.MembersRanks.FirstOrDefault(newRank) == null)
            {
                _db.MembersRanks.Add(newRank);
                _db.SaveChanges();
            }
            else
                throw new MemberDataException("Currently member rank is already present in database!");
        }

        /// <summary>
        /// Remove member rank from database.
        /// </summary>
        /// <param name="id">Id of the member rank, wich must be removed.</param>
        /// <exception cref="MemberDataException"></exception>
        public void Remove(int id)
        {
            var rankToRemove = _db.MembersRanks.FirstOrDefault(x => x.Id == id);
            if (rankToRemove != null)
            {
                _db.MembersRanks.Remove(rankToRemove);
                _db.SaveChanges();
            }
            else
                throw new MemberDataException("Can`t find currently member rank entity in database for removing.");
        }

        /// <summary>
        /// Update current member rank in database.
        /// </summary>
        /// <param name="rank">Member rank wich must be updated.</param>
        /// <exception cref="MemberDataException"></exception>
        public void Update(MemberRank rank)
        {
            if (rank != null)
                _db.MembersRanks.Update(rank);
            else
                throw new MemberDataException("Member rank is NULL!");
        }

        /// <summary>
        /// Get currently member rank.
        /// </summary>
        /// <param name="id">Member rank ID</param>
        /// <returns>MemberRank entity or NULL!</returns>
        public MemberRank GetRank(int id) => _db.MembersRanks.FirstOrDefault(x => x.Id == id);

        /// <summary>
        /// Get currently member rank.
        /// </summary>
        /// <param name="name">Member rank name</param>
        /// <returns>MemberRank entity or NULL!</returns>
        public MemberRank GetRank(string name) => _db.MembersRanks.FirstOrDefault(x => x.Name == name);

        /// <summary>
        /// Get all member ranks in database.
        /// </summary>
        /// <returns>MemberRanks collection.</returns>
        public IEnumerable<MemberRank> GetAll() => _db.MembersRanks;

        /// <summary>
        /// Get all members in currently rank.
        /// </summary>
        /// <param name="id">Member rank ID.</param>
        /// <returns>MemberRank collection.</returns>
        public List<Member> GetAllMembersInThisRank(int id) => _db.Members.Where(m => m.MemberRank.Id == id).ToList();
    }
}
