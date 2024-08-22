using CyberTech.Core.IRepositories;
using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.DataAccess.Repositories
{
    public class TournamentRepository : Repository<TournamentEntity, Guid>, ITournamentRepository
    {
        public TournamentRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
