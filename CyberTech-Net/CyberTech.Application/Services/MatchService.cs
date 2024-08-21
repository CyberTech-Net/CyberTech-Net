using AutoMapper;
using CyberTech.Core.Dto.Match;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.Application.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public MatchService(IMapper mapper, IMatchRepository matchRepository)
        {
            _mapper = mapper;
            _matchRepository = matchRepository;
        }

        public async Task<MatchDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var match = await _matchRepository.GetAsync(id, CancellationToken.None);
            return _mapper.Map<MatchEntity, MatchDto>(match);
        }

        public async Task<Guid> CreateAsync(CreatingMatchDto creatingMatchDto)
        {
            var match = _mapper.Map<CreatingMatchDto, MatchEntity>(creatingMatchDto);
            var creatingMatch = await _matchRepository.AddAsync(match);
            await _matchRepository.SaveChangesAsync();
            return creatingMatch.Id;
        }

        public async Task UpdateAsync(Guid id, UpdatingMatchDto updatingMatchDto)
        {
            var match = await _matchRepository.GetAsync(id, CancellationToken.None) ?? throw new Exception($"Запись с идентфикатором {id} не найдена");
            match.TournamentId = updatingMatchDto.TournamentId;
            match.StartDateTime = updatingMatchDto.StartDateTime;            
            _matchRepository.Update(match);
            await _matchRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var tournamentMeet = await _matchRepository.GetAsync(id, CancellationToken.None) ?? throw new Exception($"Запись с идентфикатором {id} не найдена");
            _matchRepository.Delete(tournamentMeet);
            await _matchRepository.SaveChangesAsync();
        }

        public async Task<ICollection<MatchDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            ICollection<MatchEntity> entities = await _matchRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<ICollection<MatchEntity>, ICollection<MatchDto>>(entities);
        }
    }
}
