using AutoMapper;
using CyberTech.Core.Dto.TournamentMeetTeam;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Domain.Entities;

namespace CyberTech.Application.Services
{
    public class TournamentMeetTeamService : ITournamentMeetTeamService
    {
        private readonly IMapper _mapper;
        private readonly ITournamentMeetTeamRepository _tournamentMeetTeamRepository;

        public TournamentMeetTeamService(IMapper mapper, ITournamentMeetTeamRepository tournamentMeetTeamRepository)
        {
            _mapper = mapper;
            _tournamentMeetTeamRepository = tournamentMeetTeamRepository;
        }

        public async Task<TournamentMeetTeamDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var tournamentMeetTeam = await _tournamentMeetTeamRepository.GetAsync(id, CancellationToken.None);
            return _mapper.Map<TournamentMeetTeamEntity, TournamentMeetTeamDto>(tournamentMeetTeam);
        }

        public async Task<Guid> CreateAsync(CreatingTournamentMeetTeamDto creatingTournamentMeetTeamDto)
        {
            var tournamentMeetTeam = _mapper.Map<CreatingTournamentMeetTeamDto, TournamentMeetTeamEntity>(creatingTournamentMeetTeamDto);
            var creatingTournamentMeetTeam = await _tournamentMeetTeamRepository.AddAsync(tournamentMeetTeam);
            await _tournamentMeetTeamRepository.SaveChangesAsync();
            return creatingTournamentMeetTeam.Id;
        }

        public async Task UpdateAsync(Guid id, UpdatingTournamentMeetTeamDto updatingTournamentMeetTeamDto)
        {
            var tournamentMeetTeam = await _tournamentMeetTeamRepository.GetAsync(id, CancellationToken.None);
            if (tournamentMeetTeam == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            tournamentMeetTeam.TournamentMeetId = updatingTournamentMeetTeamDto.TournamentMeetId;
            tournamentMeetTeam.TeamId = updatingTournamentMeetTeamDto.TeamId;
            tournamentMeetTeam.EarndTeam  = updatingTournamentMeetTeamDto.EarndTeam;
            tournamentMeetTeam.RatingTeam = updatingTournamentMeetTeamDto.RatingTeam;
            tournamentMeetTeam.ScoreTeam = updatingTournamentMeetTeamDto.ScoreTeam;
            tournamentMeetTeam.Win = updatingTournamentMeetTeamDto.Win;
            _tournamentMeetTeamRepository.Update(tournamentMeetTeam);
            await _tournamentMeetTeamRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var tournamentMeetTeam = await _tournamentMeetTeamRepository.GetAsync(id, CancellationToken.None);
            if (tournamentMeetTeam == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            _tournamentMeetTeamRepository.Delete(tournamentMeetTeam);
            await _tournamentMeetTeamRepository.SaveChangesAsync();
        }

        public async Task<ICollection<TournamentMeetTeamDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            ICollection<TournamentMeetTeamEntity> entities = await _tournamentMeetTeamRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<ICollection<TournamentMeetTeamEntity>, ICollection<TournamentMeetTeamDto>>(entities);
        }
    }
}
