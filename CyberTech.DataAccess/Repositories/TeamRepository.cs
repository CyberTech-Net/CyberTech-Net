using CyberTech.Core.IRepositories;
using CyberTech.Domain.Entities;

namespace CyberTech.DataAccess.Repositories
{
    public class TeamRepository : Repository<TeamEntity, Guid>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
