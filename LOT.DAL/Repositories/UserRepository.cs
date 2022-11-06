using LOT.DAL.Entities;
using LOT.DAL.Exceptions;

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

        /// <summary>
        /// Add user entity in database.
        /// </summary>
        /// <param name="user">User entity.</param>
        /// <exception cref="UserDataException"></exception>
        public void AddUser(User user)
        {
            if (user is null)
                throw new UserDataException("Attempt to add NULL user model in database!");
            else
            {
                _db.Users.Add(user);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// Remove user from database by his name.
        /// </summary>
        /// <param name="userName">Name of removing user.</param>
        /// <exception cref="UserDataException"></exception>
        public void RemoveUser(string userName)
        {
            var user = GetUser(userName);
            if (user is null)
                throw new UserDataException("Didn`t find user in database.");
            else
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// Checks if there is a user with that name in the database.
        /// </summary>
        /// <param name="userName">Searching user name.</param>
        /// <returns>TRUE, if name is free to use. FALSE, if user name is already taked.</returns>
        public bool IsUserNameIsAvailable(string userName)
        {
            if (_db.Users.FirstOrDefault(u => u.Name == userName) is null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Search user in database by his name(login).
        /// </summary>
        /// <param name="login">User name.</param>
        /// <returns>User entity.</returns>
        public User GetUser(string login) => _db.Users.FirstOrDefault(u => u.Name == login);
    }
}
