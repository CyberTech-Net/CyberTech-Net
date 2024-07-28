using CyberTech.Core.Dto.Match;

namespace CyberTech.Core.IServices
{
    public interface IMatchesService
    {
        Task<MatchDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreatingMatchDto creatingTournamentMeetDto);
        Task UpdateAsync(Guid id, UpdatingMatchDto updatingTournamentMeetDto);
        Task DeleteAsync(Guid id);
        Task<List<MatchDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
