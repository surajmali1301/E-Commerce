using Mini_Project_DotNet.Models;

namespace Mini_Project_DotNet.Services
{
    public interface IUserService
    {
        IEnumerable<Users> GetUserList();
        int AddUser(Users users);

        Users GetUser(string email, int password);

        int UpdateUser(Users users);

        int DeleteUser(int id);

        Users GetUserById(int id);
    }
}
