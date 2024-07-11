using CyberTech.Core.IRepositories;
using CyberTech.Domain.Entities;

namespace CyberTech.DataAccess.Repositories
{
    public class RoleRepository : Repository<RoleEntity, Guid>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {     
        }
    }
}
