using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Core.IRepositories
{
    public interface ITeamRepository : IRepository<Team, Guid>
    {
        Task<List<Team>> GetPagedAsync(int page, int itemsPerPage);
    }
}
