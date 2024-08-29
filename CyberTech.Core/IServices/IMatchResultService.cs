using CyberTech.Core.Dto.MatchResult;

namespace CyberTech.Core.IServices
{
    public interface IMatchResultService
    {
        Task<MatchResultDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreatingMatchResultDto creatingMatchResultTeamDto);
        Task CreateResultAsync(CreatingMatchResultDto creatingResultDtoFirst, CreatingMatchResultDto creatingResultDtoSecond);
        Task UpdateAsync(Guid id, UpdatingMatchResultDto updatingTournamentMeetTeamDto);
        Task DeleteAsync(Guid id);
        Task<ICollection<MatchResultDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
