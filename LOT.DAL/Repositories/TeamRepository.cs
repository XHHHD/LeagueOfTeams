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
        public void UpdateTeam(Team team)
        {
            _db.Update(team);
        }
        public void RemoveTeam(Team team)
        {
            _db.Teams.Remove(team);
            _db.SaveChanges();
        }
        public async void RemoveTeamByIdAsync(int id)
        {
            Team teamToRemove = await _db.Teams.FindAsync(id);
            if(teamToRemove != null) await Task.Run(() => _db.Teams.Remove(teamToRemove));
        }
        public Team GetTeamById(int id) => _db.Teams.FirstOrDefault(t => t.Id == id);
        public IEnumerable<Member> GetTeamMembers(int id) => _db.Members.Where(m => m.TeamId == id);
        public IEnumerable<Team> GetAll() => _db.Teams.ToList();
    }
}
