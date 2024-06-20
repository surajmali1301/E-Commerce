using Mini_Project_DotNet.Models;

namespace Mini_Project_DotNet.Repository
{
    public interface IUserRepository
    {
        IEnumerable<Users> GetUserList();
        int AddUser(Users users);
        Users GetUser(string email, int passoword);

        Users GetUserById(int id);

        int UpdateUser(Users users);

        int DeleteUser(int id);

      
    }
}
