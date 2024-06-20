using Mini_Project_DotNet.Models;
using Mini_Project_DotNet.Repository;

namespace Mini_Project_DotNet.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repo;
        public UserService(IUserRepository repo)
        {
            this.repo = repo;
        }
        public int AddUser(Users users)
        {
           return repo.AddUser(users);
        }

        public int DeleteUser(int id)
        {
            return repo.DeleteUser(id);
        }

        public Users GetUser(string email, int password)
        {
            return repo.GetUser(email,password);
        }

        public Users GetUserById(int id)
        {
            return repo.GetUserById(id);
        }

        public IEnumerable<Users> GetUserList()
        {
            return repo.GetUserList();
        }

        public int UpdateUser(Users users)
        {
            return repo.UpdateUser(users);
        }
    }
}
