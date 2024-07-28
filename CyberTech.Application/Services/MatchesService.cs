using CyberTech.Core.Dto.Match;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Core.Mapping;
using CyberTech.MessagesContracts.TournamentMeets;

namespace CyberTech.Application.Services
{
    public class MatchesService(ITournamentMeetRepository tournamentMeetRepository, IRabbitMqService mqService) : IMatchesService
    {
        private readonly ITournamentMeetRepository _tournamentMeetRepository = tournamentMeetRepository;
        private readonly IRabbitMqService _mqService = mqService;

        public async Task<MatchDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var tournamentMeet = await _tournamentMeetRepository.GetAsync(id, CancellationToken.None);
            if (tournamentMeet == null)
                return default;

            return MatchMapper.ConvertToDto(tournamentMeet);
        }

        public async Task<Guid> CreateAsync(CreatingMatchDto creatingMatchDto)
        {
            var creatingMatch = await _tournamentMeetRepository.AddAsync(MatchMapper.ConvertToBaseModel(creatingMatchDto));
            await _tournamentMeetRepository.SaveChangesAsync();
            _mqService.SendMessage(new MatchPlanned(creatingMatch.Id, creatingMatch.StartDateTime, firtstTeamId: creatingMatch.FirtstTeamId, secondTeamId: creatingMatch.SecondTeamId));
            return creatingMatch.Id;
        }

        public async Task UpdateAsync(Guid id, UpdatingMatchDto updatingMatchDto)
        {
            var match = await _tournamentMeetRepository.GetAsync(id, CancellationToken.None) ?? throw new Exception($"Запись с идентфикатором {id} не найдена");

            match.Update(updatingMatchDto.TournamentId, updatingMatchDto.StartDateTime);
            _tournamentMeetRepository.Update(match);
            await _tournamentMeetRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var tournamentMeet = await _tournamentMeetRepository.GetAsync(id, CancellationToken.None) ?? throw new Exception($"Запись с идентфикатором {id} не найдена");
            _tournamentMeetRepository.Delete(tournamentMeet);
            await _tournamentMeetRepository.SaveChangesAsync();
        }

        public async Task<List<MatchDto>?> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _tournamentMeetRepository.GetAllAsync(cancellationToken);
            if (entities == null)
                return default;
            return MatchMapper.ConvertToDto(entities);
        }
    }
}
