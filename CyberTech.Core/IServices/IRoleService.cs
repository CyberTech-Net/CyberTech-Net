using CyberTech.Core.Dto.Role;

namespace CyberTech.Core.IServices
{
    public interface IRoleService
    {
        Task<ICollection<RoleDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
