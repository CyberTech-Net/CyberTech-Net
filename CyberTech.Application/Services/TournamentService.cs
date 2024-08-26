using AutoMapper;
using CyberTech.Core.Dto.Tournament;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.Application.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly IMapper _mapper;
        private readonly ITournamentRepository _tournamentRepository;

        public TournamentService(IMapper mapper, ITournamentRepository tournamentRepository)
        {
            _mapper = mapper;
            _tournamentRepository = tournamentRepository;
        }

        public async Task<TournamentDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var tournament = await _tournamentRepository.GetAsync(id, CancellationToken.None);
            if (tournament == null) return default;
            return _mapper.Map<TournamentEntity, TournamentDto>(tournament);
        }

        public async Task<Guid> CreateAsync(CreatingTournamentDto creatingTournamentDto, CancellationToken cancellationToken = default)
        {
            var tournament = _mapper.Map<CreatingTournamentDto, TournamentEntity>(creatingTournamentDto);
            var creatingTournament = await _tournamentRepository.AddAsync(tournament);
            await _tournamentRepository.SaveChangesAsync();
            return creatingTournament.Id;
        }

        public async Task UpdateAsync(Guid id, UpdatingTournamentDto updatingTournamentDto, CancellationToken cancellationToken = default)
        {
            var tournament = await _tournamentRepository.GetAsync(id, CancellationToken.None) ?? throw new Exception($"Запись с идентфикатором {id} не найдена");
            tournament.TitleTournament = updatingTournamentDto.TitleTournament;
            tournament.DateTournamentInit = updatingTournamentDto.DateTournamentInit;
            tournament.DateTournamentEnd = updatingTournamentDto.DateTournamentEnd;
            tournament.PlaceName = updatingTournamentDto.PlaceName;
            tournament.EarndTournament = updatingTournamentDto.EarndTournament;
            tournament.GameTypeId = updatingTournamentDto.GameTypeId;
            _tournamentRepository.Update(tournament);
            await _tournamentRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var tournament = await _tournamentRepository.GetAsync(id, CancellationToken.None) ?? throw new Exception($"Запись с идентфикатором {id} не найдена");
            _tournamentRepository.Delete(tournament);
            await _tournamentRepository.SaveChangesAsync();
        }

        public async Task<ICollection<TournamentDto>> GetPagedAsync(int page, int pageSize, CancellationToken cancellationToken = default)
        {
            ICollection<TournamentEntity> entities = await _tournamentRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<TournamentEntity>, ICollection<TournamentDto>>(entities);
        }

        public async Task<ICollection<TournamentDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            ICollection<TournamentEntity> entities = await _tournamentRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<ICollection<TournamentEntity>, ICollection<TournamentDto>>(entities);
        }
    }
}
