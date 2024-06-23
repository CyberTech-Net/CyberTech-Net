using CyberTech.Core.IRepositories;
using CyberTech.Domain.Entities;

namespace CyberTech.DataAccess.Repositories
{
    public class TournamentMeetTeamRepository : Repository<TournamentMeetTeamEntity, Guid>, ITournamentMeetTeamRepository
    {
        public TournamentMeetTeamRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
