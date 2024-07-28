using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Core.IRepositories
{
    public interface IPlayerRepository : IRepository<Player, Guid>
    {
        Task<List<Player>> GetPagedAsync(int page, int itemsPerPage);
    }
}
