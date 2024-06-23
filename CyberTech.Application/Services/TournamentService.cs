using AutoMapper;
using CyberTech.Core.Dto.Tournament;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Domain.Entities;

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

        public async Task<TournamentDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var tournament = await _tournamentRepository.GetAsync(id, CancellationToken.None);
            return _mapper.Map<TournamentEntity, TournamentDto>(tournament);
        }

        public async Task<Guid> CreateAsync(CreatingTournamentDto creatingTournamentDto)
        {
            var tournament = _mapper.Map<CreatingTournamentDto, TournamentEntity>(creatingTournamentDto);
            var creatingTournament = await _tournamentRepository.AddAsync(tournament);
            await _tournamentRepository.SaveChangesAsync();
            return creatingTournament.Id;
        }

        public async Task UpdateAsync(Guid id, UpdatingTournamentDto updatingTournamentDto)
        {
            var tournament = await _tournamentRepository.GetAsync(id, CancellationToken.None);
            if (tournament == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            tournament.TitleTournament = updatingTournamentDto.TitleTournament;
            tournament.DataTournamentInit = updatingTournamentDto.DataTournamentInit;
            tournament.DataTournamentEnd = updatingTournamentDto.DataTournamentEnd;
            tournament.PlaceName = updatingTournamentDto.PlaceName;
            tournament.EarndTournament = updatingTournamentDto.EarndTournament;
            tournament.GameTypeId = updatingTournamentDto.GameTypeId;
            _tournamentRepository.Update(tournament);
            await _tournamentRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var tournament = await _tournamentRepository.GetAsync(id, CancellationToken.None);
            if (tournament == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            _tournamentRepository.Delete(tournament);
            await _tournamentRepository.SaveChangesAsync();
        }

        public async Task<ICollection<TournamentDto>> GetPagedAsync(int page, int pageSize)
        {
            ICollection<TournamentEntity> entities = await _tournamentRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<TournamentEntity>, ICollection<TournamentDto>>(entities);
        }

        public async Task<ICollection<TournamentDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            ICollection<TournamentEntity> entities = await _tournamentRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<ICollection<TournamentEntity>, ICollection<TournamentDto>>(entities);
        }
    }
}
