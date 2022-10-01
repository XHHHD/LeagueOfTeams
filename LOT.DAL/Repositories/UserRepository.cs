using LOT.DAL.Entities;

namespace LOT.DAL.Repositories
{
    public class UserRepository
    {
        AppContext _db;
        public UserRepository()
        {
            string dbConnectionString =
                "Server=(localdb)\\mssqllocaldb;Initial Catalog=MyDB;Integrated Security=True;";
            _db = new AppContext(dbConnectionString);
        }
        public List<User> GetAllUsers()
        {
            return _db.Users.ToList();
        }
        public void AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }
        public void RemoveUser(User user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }
        public Team GetUserTeam(User user) => _db.Teams.FirstOrDefault(t => t.User == user);
    }
}
