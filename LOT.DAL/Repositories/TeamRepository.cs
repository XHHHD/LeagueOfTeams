using LOT.DAL.Entities;

namespace LOT.DAL.Repositories
{
    public class TeamRepository
    {
        AppContext _db;
        public TeamRepository()
        {
            string dbConnectionString =
                "Server=(localdb)\\mssqllocaldb;Initial Catalog=MyDB;Integrated Security=True;";
            _db = new AppContext(dbConnectionString);
        }
        public void AddTeam(Team team)
        {
            _db.Teams.Add(team);
            _db.SaveChanges();
        }
        public void RemoveTeam(Team team)
        {
            _db.Teams.Remove(team);
            _db.SaveChanges();
        }
        public List<Team> GetAll() => _db.Teams.ToList();
        public Team GetTeamById(int id) => _db.Teams.FirstOrDefault( t => t.Id == id);
        public List<Member> GetTeamMembers(Team team) => _db.Members.Where(m => m.TeamId == team.Id).ToList();
    }
}
