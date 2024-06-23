using CyberTech.Domain.Entities;

namespace CyberTech.Core.IRepositories
{
    public interface ITournamentRepository : IRepository<TournamentEntity, Guid>
    {
        Task<List<TournamentEntity>> GetPagedAsync(int page, int itemsPerPage);
    }
}
