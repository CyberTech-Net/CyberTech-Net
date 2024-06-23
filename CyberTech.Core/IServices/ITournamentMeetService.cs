using CyberTech.Core.Dto.TournamentMeet;

namespace CyberTech.Core.IServices
{
    public interface ITournamentMeetService
    {
        Task<TournamentMeetDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreatingTournamentMeetDto creatingTournamentMeetDto);
        Task UpdateAsync(Guid id, UpdatingTournamentMeetDto updatingTournamentMeetDto);
        Task DeleteAsync(Guid id);
        Task<ICollection<TournamentMeetDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
