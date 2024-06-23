using CyberTech.Core.Dto.TournamentMeetTeam;

namespace CyberTech.Core.IServices
{
    public interface ITournamentMeetTeamService
    {
        Task<TournamentMeetTeamDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreatingTournamentMeetTeamDto creatingTournamentMeetTeamDto);
        Task UpdateAsync(Guid id, UpdatingTournamentMeetTeamDto updatingTournamentMeetTeamDto);
        Task DeleteAsync(Guid id);
        Task<ICollection<TournamentMeetTeamDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
