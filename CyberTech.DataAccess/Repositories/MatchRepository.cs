using CyberTech.Core.IRepositories;
using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.DataAccess.Repositories
{
    public class MatchRepository(ApplicationDbContext context) : Repository<Match, Guid>(context), ITournamentMeetRepository
    {
    }
}
