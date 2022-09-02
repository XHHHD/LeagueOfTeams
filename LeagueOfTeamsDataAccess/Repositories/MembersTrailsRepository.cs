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
        public List<MemberTrail> GetAllMembersTrails()
        {
            return _db.MembersTrails.ToList();
        }
        public MemberTrail GetMemberTrail(int trailID)
        {
            return _db.MembersTrails.ElementAtOrDefault(trailID);
        }
    }
}
