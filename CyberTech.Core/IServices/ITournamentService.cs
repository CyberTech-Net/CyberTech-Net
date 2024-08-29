using CyberTech.Core.Dto.Tournament;

namespace CyberTech.Core.IServices
{
    public interface ITournamentService
    {
        Task<TournamentDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Guid> CreateAsync(CreatingTournamentDto creatingTournamentDto, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid id, UpdatingTournamentDto updatingTournamentDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ICollection<TournamentDto>> GetPagedAsync(int page, int pageSize, CancellationToken cancellationToken = default);
        Task<ICollection<TournamentDto>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
