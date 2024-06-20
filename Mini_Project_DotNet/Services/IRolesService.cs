using Mini_Project_DotNet.Models;

namespace Mini_Project_DotNet.Services
{
    public interface IRolesService
    {
        IEnumerable<Roles> GetRoles();
    }
}
