using CyberTech.Core.IRepositories;
using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.DataAccess.Repositories
{
    public class MatchRepository : Repository<MatchEntity, Guid>, IMatchRepository
    {
        public MatchRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
