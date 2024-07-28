using CyberTech.Core.Dto.News;

namespace CyberTech.Core.IServices
{
    public interface IInfoService                
    {
        Task<NewsDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreatingNewsDto creatingInfoDto);
        Task UpdateAsync(Guid id, UpdatingNewsDto updatingInfoDto);
        Task DeleteAsync(Guid id);
        Task<List<NewsDto>> GetPagedAsync(int page, int pageSize);
        Task<List<NewsDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
