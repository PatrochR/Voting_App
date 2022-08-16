using Models.Context;
using Voting_App.Models;

namespace Voting_App.Repository
{
    
    public interface IUserRegister
    {
        IEnumerable<User> GetAllUser();
        User GetUserByUserName(string username);
        bool IsExistUserByUserName(string username);
        bool AddUser(User user);
        bool ChangeUserName(int userId , string newUserName);
        User GetUserForLogin (string username ,string password);
    }

    public class UserRegister : IUserRegister
    {
        private readonly Context _context;
        public UserRegister(Context context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAllUser()
        {
            return _context.Users;
        }
        public User GetUserByUserName(string username)
        {
            return _context.Users.SingleOrDefault(user => user.UserNameConfirmed == username.ToUpper());
        }
        public bool AddUser(User user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ChangeUserName(int userId , string newUserName)
        {
            try
            {
                var user = _context.Users.Find(userId);
                user.UserName = newUserName;
                user.UserNameConfirmed = newUserName.ToUpper();
                _context.SaveChanges(); 
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsExistUserByUserName(string username)
        {
           return _context.Users.Any(a => a.UserNameConfirmed == username.ToUpper());
        }

        public User GetUserForLogin(string username, string password)
        {
            return _context.Users
                .SingleOrDefault(user => user.UserName == username && user.Password == password  && user.UserName == username.ToUpper());
        }
    }
}