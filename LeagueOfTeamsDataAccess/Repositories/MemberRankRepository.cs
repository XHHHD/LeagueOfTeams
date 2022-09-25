using LeagueOfTeamsDataAccess.Entities;

namespace LeagueOfTeamsDataAccess.Repositories
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
        public void AddNewRank(MemberRank newRank)
        {
            _db.Add(newRank);
            _db.SaveChanges();
        }
        public void RemoveRank(MemberRank rank)
        {
            _db.Remove(rank);
            _db.SaveChanges();
        }
        public List<MemberRank> GetAllRanks() => _db.MembersRanks.ToList();
        public List<Member> GetAllMembersInThisRank(MemberRank rank) => _db.Members.Where(m => m.MemberRank == rank).ToList();
    }
}
