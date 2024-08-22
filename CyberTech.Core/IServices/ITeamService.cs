using CyberTech.Core.Dto.Team;

namespace CyberTech.Core.IServices
{
    public interface ITeamService
    {
        Task<TeamDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreatingTeamDto creatingTeamDto);
        Task UpdateAsync(Guid id, UpdatingTeamDto updatingTeamDto);
        Task DeleteAsync(Guid id);
        Task<ICollection<TeamDto>> GetPagedAsync(int page, int pageSize);
        Task<ICollection<TeamDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
