using CyberTech.Core.Dto.Player;

namespace CyberTech.Core.IServices
{
    public interface IPlayerService
    {
        Task<PlayerDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreatingPlayerDto creatingPlayerDto);
        Task UpdateAsync(Guid id, UpdatingPlayerDto updatingPlayerDto);
        Task DeleteAsync(Guid id);
        Task<ICollection<PlayerDto>> GetPagedAsync(int page, int pageSize);
        Task<ICollection<PlayerDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
