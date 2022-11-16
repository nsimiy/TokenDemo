using TokenDemo.Data;
using TokenDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace TokenDemo.App_Repositories.User_Account
{
    public class UserRepo : IUserRepo
    {
        private readonly TokenDbContext _tokenDbContext;
        public UserRepo(TokenDbContext tokenDbContext)
        {
            _tokenDbContext = tokenDbContext;
        }
        public  User createUser(User user)
        {
             _tokenDbContext.Beta.Add(user);
             _tokenDbContext.SaveChanges();
            return user;
        }


        public User DeleteUser(int UserId)
        {
            var delete = _tokenDbContext.Beta.Find(UserId);
            _tokenDbContext.Beta.Remove(delete);
            _tokenDbContext.SaveChanges();
            return delete;
        }

        public bool loginUser(UserLogin userlogin)
        {
            throw new NotImplementedException();
        }

        public User updateUser(User user)
        {
            var User = _tokenDbContext.Beta.FirstOrDefault(x => x.UserId == user.UserId);
            if (User == null)
            {
                user.UserName = user.UserName;
                user.EmailAddress = user.EmailAddress;
                user.Password = user.Password;
                user.GivenName = user.GivenName;
                user.SurName = user.SurName;
                user.Role = user.Role;

                _tokenDbContext.SaveChanges();
                return User;
            }
            return null;
        }

        Movie IUserRepo.Delete(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
