using CyberTech.Domain.Entities;

namespace CyberTech.Core.IRepositories
{
    public interface ITeamRepository : IRepository<TeamEntity, Guid>
    {
        Task<List<TeamEntity>> GetPagedAsync(int page, int itemsPerPage);
    }
}
