using LeagueOfTeamsDataAccess.Entities;

namespace LeagueOfTeamsDataAccess.Repositories
{
    public class MembersTrailsRepository
    {
        AppContext _db;
        public MembersTrailsRepository()
        {
            string dbConnectionString =
                "Server=(localdb)\\mssqllocaldb;Initial Catalog=MyDB;Integrated Security=True;";
            _db = new AppContext(dbConnectionString);
        }
        public void AddMemberTrail(MemberTrail trail)
        {
            _db.MembersTrails.Add(trail);
            _db.SaveChanges();
        }
        public void RemoveTrail(MemberTrail trail)
        {
            _db.MembersTrails.Remove(trail);
            _db.SaveChanges();
        }
        public MemberTrail GetMemberTrail(int trailID)
        {
            return _db.MembersTrails.ElementAtOrDefault(trailID);
        }
        public List<MemberTrail> GetAllMembersTrails()
        {
            return _db.MembersTrails.ToList();
        }
    }
}
