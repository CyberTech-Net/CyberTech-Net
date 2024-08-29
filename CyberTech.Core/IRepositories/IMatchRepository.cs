using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.Core.IRepositories
{
    public interface IMatchRepository : IRepository<MatchEntity, Guid>
    {
    }
}