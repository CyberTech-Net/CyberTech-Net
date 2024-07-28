using CyberTech.Core.IRepositories;
using CyberTech.Domain.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace CyberTech.DataAccess.Repositories
{
    public class MatchResultRepository(ApplicationDbContext context) : Repository<MatchResult, Guid>(context), IMatchResultRepository
    {
        public override async Task<MatchResult?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await GetAll()
                .Where(x => x.Id == id)
                .Include(x => x.Match)
                .Include(x => x.Team)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public new async Task<List<MatchResult>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
        {
            return await GetAll()
                .Include(x => x.Match)
                .Include(x => x.Team)
                .ToListAsync(cancellationToken);
        }
    }
}
