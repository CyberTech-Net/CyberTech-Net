using CyberTech.Core.Dto.InfoImage;

namespace CyberTech.Core.IServices
{
    public interface IInfoImageService
    {
        Task<InfoImageDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreatingInfoImageDto creatingInfoImageDto);
        Task UpdateAsync(Guid id, UpdatingInfoImageDto updatingInfoImageDto);
        Task DeleteAsync(Guid id);
        Task<ICollection<InfoImageDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
