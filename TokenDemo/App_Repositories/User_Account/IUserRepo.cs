

using TokenDemo.Models;

namespace TokenDemo.App_Repositories.User_Account
{
    public interface IUserRepo
    {
        User createUser(User user);
        bool loginUser(UserLogin userlogin);

        User updateUser(User user);
        public Movie Delete(int UserId);


    }
}
