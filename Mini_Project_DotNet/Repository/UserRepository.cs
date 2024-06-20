using Mini_Project_DotNet.Data;
using Mini_Project_DotNet.Models;

namespace Mini_Project_DotNet.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext db;
        public UserRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Users> GetUserList()
        {
                var userList = (from users in  db.Users
                                select users).ToList();

            return userList;

        }
      public int AddUser(Users users)

        {
            int result = 0;
            db.Users.Add(users);
            result = db.SaveChanges();
            return result;
        }

        public Users GetUser(string email, int password)
        {
            try
            {
                return db.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("Error retrieving user", ex);
            }
        }

        public int UpdateUser(Users users)
        {
            int result = 0;
            db.Users.Update(users);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteUser(int id)
        {
            var model = db.Users.SingleOrDefault(u=>u.Id==id);
            if(model != null)
            {
                db.Users.Remove(model);
                return db.SaveChanges();
            }
            return 0;
            
        }

        public Users GetUserById(int id)
        {
            return db.Users.Where(x=>x.Id==id).SingleOrDefault();
        }
    }
}
