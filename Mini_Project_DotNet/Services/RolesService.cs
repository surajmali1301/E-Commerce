using Mini_Project_DotNet.Models;
using Mini_Project_DotNet.Repository;

namespace Mini_Project_DotNet.Services
{
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository rolesRepo;

        public RolesService(IRolesRepository rolesRepo)
        {
            this.rolesRepo = rolesRepo;
        }
        public IEnumerable<Roles> GetRoles()
        {
            return rolesRepo.GetRoles();
        }
    }
}
