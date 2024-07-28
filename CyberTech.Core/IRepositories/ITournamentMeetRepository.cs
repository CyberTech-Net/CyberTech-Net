using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.Core.IRepositories
{
    public interface ITournamentMeetRepository : IRepository<Match, Guid>
    {
    }
}