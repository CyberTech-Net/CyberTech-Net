using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.Core.IRepositories
{
    public interface ITournamentRepository : IRepository<Tournament, Guid>
    {
        Task<List<Tournament>> GetPagedAsync(int page, int itemsPerPage);
    }
}
