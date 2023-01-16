using System;
using EFCoreInMemoryDbDemo;

namespace userWebApi.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetByUsername(string username);
        void Create(User user);
        void Update(string username, UpdateUserModel user);
        void Delete(string username);
    }

    public class UserService : IUserService
    {
        private ApiContext _context;

        public UserService(
            ApiContext context)
        {
            _context = context;
        }

        private User getUser(string username)
        {
            var user = _context.Users.ToList().Find(u=>u.UserName.Equals(username));
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public User GetByUsername(string username)
        {
            return getUser(username);
        }

        public void Create(User user)
        {
            if (_context.Users.Any(x => x.UserEmail == user.UserEmail || x.UserName == user.UserName))
                throw new Exception("Username or email already taken");
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(string username, UpdateUserModel model)
        {
            var user = getUser(username);

            if (model.UserEmail != user.UserEmail && _context.Users.Any(x => x.UserEmail == model.UserEmail))
                throw new Exception("Username or email already taken");

            user.FirstName = model.FirstName;
            user.UserEmail = model.UserEmail;
            user.UserWebSite = model.UserWebSite;

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(string username)
        {
            var user = getUser(username);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }



    }
}

