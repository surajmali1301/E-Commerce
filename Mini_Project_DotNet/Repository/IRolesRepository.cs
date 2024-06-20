using Mini_Project_DotNet.Models;

namespace Mini_Project_DotNet.Repository
{
    public interface IRolesRepository
    {
        IEnumerable<Roles> GetRoles();
    }
}
