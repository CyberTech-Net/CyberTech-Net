using CyberTech.Core.Dto.TeamPlayer;

namespace CyberTech.Core.IServices
{
    public interface ITeamPlayerService
    {
        Task<TeamPlayerDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreatingTeamPlayerDto creatingTeamPlayerDto);
        Task UpdateAsync(Guid id, UpdatingTeamPlayerDto updatingteamPlayerDto);
        Task DeleteAsync(Guid id);
        Task<ICollection<TeamPlayerDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
