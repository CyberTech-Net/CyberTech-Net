using CyberTech.Core.IRepositories;
using CyberTech.Domain.Entities;

namespace CyberTech.DataAccess.Repositories
{
    public class TournamentRepository : Repository<TournamentEntity, Guid>, ITournamentRepository
    {
        public TournamentRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
