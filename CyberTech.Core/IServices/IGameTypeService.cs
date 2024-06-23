using CyberTech.Core.Dto.GameType;

namespace CyberTech.Core.IServices
{
    public interface IGameTypeService                
    {
        Task<GameTypeDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<ICollection<GameTypeDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreatingGameTypeDto creatingGameTypeDto);
        Task UpdateAsync(Guid id, UpdatingGameTypeDto updatingGameTypeDto);
        Task DeleteAsync(Guid id);
    }
}
