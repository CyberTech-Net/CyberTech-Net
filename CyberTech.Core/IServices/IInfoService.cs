using CyberTech.Core.Dto.Info;

namespace CyberTech.Core.IServices
{
    public interface IInfoService                
    {
        Task<InfoDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreatingInfoDto creatingInfoDto);
        Task UpdateAsync(Guid id, UpdatingInfoDto updatingInfoDto);
        Task DeleteAsync(Guid id);
        Task<ICollection<InfoDto>> GetPagedAsync(int page, int pageSize);
        Task<ICollection<InfoDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
