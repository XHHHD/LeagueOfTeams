using AutoMapper;
using LOT.BLL.Exceptions;
using LOT.BLL.Models;
using LOT.DAL.Entities;
using LOT.DAL.Repositories;

namespace LOT.BLL.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _mapper = MappingHelper.GetMapper();
            _userRepository = new();
        }

        public void AddUser(UserModel model)
        {
            if (model is null)
                throw new UserServiceException("Attempt to add NULL user model in database!");
            else
            {
                var entity = _mapper.Map<User>(model);
                _userRepository.AddUser(entity);
                model.Id = entity.Id;
            }
        }


        /// <summary>
        /// Get user model from database by user name(login).
        /// </summary>
        /// <param name="loggin">User name(loggin)</param>
        /// <returns>User model or NULL.</returns>
        private UserModel GetUser(string loggin)
        {
            var entity = _userRepository.GetUser(loggin);
            if (entity is null)
                return null;
            else
                return _mapper.Map<UserModel>(entity);
        }

        /// <summary>
        /// Compares the password with the user's password.
        /// </summary>
        /// <param name="user">User model.</param>
        /// <param name="password">Entered password.</param>
        /// <returns>TRUE, if the password is correct. FALSE, if the password is not correct.</returns>
        private bool Verification(UserModel user, string password)
        {
            if(user.Password == password)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Search user by name in database. Validate user name and password.
        /// If <paramref name="login"/> and <paramref name="password"/> is correct - method fill in <paramref name="user"/>.
        /// Otherwise, the method will NULL the model.
        /// </summary>
        /// <param name="user">An empty user model to fill in.</param>
        /// <param name="login">Searcing user model name.</param>
        /// <param name="password">Verification password.</param>
        /// <exception cref="UserServiceException"></exception>
        public void Authorization(UserModel user, string login, string password)
        {
            var userFromDB = GetUser(login);
            if (userFromDB is null)
            {
                user = null;
            }
            else
            {
                if (Verification(userFromDB, password))
                    user = userFromDB;
                else
                    user = null;
            }
        }

        /// <summary>
        /// If the username is free, creates a new user entity in the database. Otherwise - NULL user model.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Actual user model of defoult user object.</returns>
        public UserModel RegisterNewUser(string login, string password)
        {
            var user = GenerateNewUser(login, password);

            if (GetUser(user.Name) is null)
            {
                AddUser(user);
            }
            else
            {
                user = null;
            }
            return user;
        }

        private UserModel GenerateNewUser(string login, string password)
        {
            UserModel user = new()
            {
                Name = login,
                Password = password,
                Expiriance = 0
            };
            return user;
        }
    }
}
