using CyberTech.Core.Dto.MatchResult;

namespace CyberTech.Core.IServices
{
    public interface IMatchResultsService
    {
        Task<ResultDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreatingResultDto creatingTournamentMeetTeamDto);
        Task UpdateAsync(Guid id, UpdatingResultDto updatingTournamentMeetTeamDto);
        Task DeleteAsync(Guid id);
        Task<List<ResultDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
