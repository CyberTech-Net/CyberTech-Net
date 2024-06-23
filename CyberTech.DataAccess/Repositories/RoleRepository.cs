using CyberTech.Core.IRepositories;
using CyberTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberTech.DataAccess.Repositories
{
    public class RoleRepository : Repository<RoleEntity, Guid>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {     
        }
    }
}
