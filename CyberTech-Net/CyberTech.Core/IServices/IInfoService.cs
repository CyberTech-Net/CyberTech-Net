using CyberTech.Core.Dto.News;

namespace CyberTech.Core.IServices
{
    public interface IInfoService                
    {
        Task<InfoDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreatingInfoDto creatingInfoDto);
        Task UpdateAsync(Guid id, UpdatingInfoDto updatingInfoDto);
        Task DeleteAsync(Guid id);
        Task<List<InfoDto>> GetPagedAsync(int page, int pageSize);
        Task<List<InfoDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<string> GetNewImageIdAsync(Guid id);
    }
}
