using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.Core.IRepositories
{
    public interface ITournamentRepository : IRepository<TournamentEntity, Guid>
    {
        Task<List<TournamentEntity>> GetPagedAsync(int page, int itemsPerPage);
    }
}
