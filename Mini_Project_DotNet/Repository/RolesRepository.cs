using Mini_Project_DotNet.Data;
using Mini_Project_DotNet.Models;

namespace Mini_Project_DotNet.Repository
{
    public class RolesRepository : IRolesRepository
    {
        private readonly ApplicationDbContext db;

        public RolesRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Roles> GetRoles()
        {
            var model = (from roles in db.Roles
                         select roles);
            return model;
        }
    }
}
