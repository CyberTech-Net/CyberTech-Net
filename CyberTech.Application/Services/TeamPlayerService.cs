using AutoMapper;
using CyberTech.Core.Dto.TeamPlayer;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Domain.Entities;

namespace CyberTech.Application.Services
{
    public class TeamPlayerService: ITeamPlayerService
    {
        private readonly IMapper _mapper;
        private readonly ITeamPlayerRepository _teamPlayerRepository;

        public TeamPlayerService(IMapper mapper, ITeamPlayerRepository teamPlayerRepository)
        {
            _mapper = mapper;
            _teamPlayerRepository = teamPlayerRepository;
        }

        public async Task<TeamPlayerDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var teamPlayer = await _teamPlayerRepository.GetAsync(id, CancellationToken.None);
            return _mapper.Map<TeamPlayerEntity, TeamPlayerDto>(teamPlayer);
        }

        public async Task<Guid> CreateAsync(CreatingTeamPlayerDto creatingTeamPlayerDto)
        {
            var team = _mapper.Map<CreatingTeamPlayerDto, TeamPlayerEntity>(creatingTeamPlayerDto);
            var creatingTeamPlayer = await _teamPlayerRepository.AddAsync(team);
            await _teamPlayerRepository.SaveChangesAsync();
            return creatingTeamPlayer.Id;
        }

        public async Task UpdateAsync(Guid id, UpdatingTeamPlayerDto updatingTeamPlayerDto)
        {
            var teamPlayer = await _teamPlayerRepository.GetAsync(id, CancellationToken.None);
            if (teamPlayer == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            teamPlayer.PlayerId = updatingTeamPlayerDto.PlayerId;
            teamPlayer.TeamId = updatingTeamPlayerDto.TeamId;
            teamPlayer.Year1 = updatingTeamPlayerDto.Year1;
            teamPlayer.Year2 = updatingTeamPlayerDto.Year2;
            _teamPlayerRepository.Update(teamPlayer);
            await _teamPlayerRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var teamPlayer = await _teamPlayerRepository.GetAsync(id, CancellationToken.None);
            if (teamPlayer == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            _teamPlayerRepository.Delete(teamPlayer);
            await _teamPlayerRepository.SaveChangesAsync();
        }

        public async Task<ICollection<TeamPlayerDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            ICollection<TeamPlayerEntity> entities = await _teamPlayerRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<ICollection<TeamPlayerEntity>, ICollection<TeamPlayerDto>>(entities);
        }
    }
}
