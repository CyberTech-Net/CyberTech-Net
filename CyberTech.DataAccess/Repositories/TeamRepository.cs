using CyberTech.Core.IRepositories;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.DataAccess.Repositories
{
    public class TeamRepository : Repository<TeamEntity, Guid>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
