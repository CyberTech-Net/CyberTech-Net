using CyberTech.Core.IRepositories;
using CyberTech.Domain.Entities;

namespace CyberTech.DataAccess.Repositories
{
    public class TournamentMeetRepository : Repository<TournamentMeetEntity, Guid>, ITournamentMeetRepository
    {
        public TournamentMeetRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
