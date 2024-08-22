using CyberTech.Core.IRepositories;
using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.DataAccess.Repositories
{
    public class MatchResultRepository : Repository<MatchResultEntity, Guid>, IMatchResultRepository
    {
        public MatchResultRepository(ApplicationDbContext context) : base(context)
        {            
        }
    }
}
