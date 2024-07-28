using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Core.IRepositories
{
    public interface IInfoRepository : IRepository<News, Guid>
    {
        Task<List<News>> GetPagedAsync(int page, int itemsPerPage);
    }
}
