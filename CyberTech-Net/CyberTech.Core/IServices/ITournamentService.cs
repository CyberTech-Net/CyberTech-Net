using CyberTech.Core.Dto.Tournament;

namespace CyberTech.Core.IServices
{
    public interface ITournamentService
    {
        Task<TournamentDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreatingTournamentDto creatingTournamentDto);
        Task UpdateAsync(Guid id, UpdatingTournamentDto updatingTournamentDto);
        Task DeleteAsync(Guid id);
        Task<ICollection<TournamentDto>> GetPagedAsync(int page, int pageSize);
        Task<ICollection<TournamentDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
