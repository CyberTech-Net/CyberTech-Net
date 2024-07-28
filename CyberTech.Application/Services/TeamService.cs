using AutoMapper;
using CyberTech.Core.Dto.Team;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;

        public TeamService(IMapper mapper, ITeamRepository teamRepository)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
        }

        public async Task<TeamDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetAsync(id, CancellationToken.None);
            return _mapper.Map<Team, TeamDto>(team);
        }

        public async Task<Guid> CreateAsync(CreatingTeamDto creatingTeamDto)
        {
            var team = _mapper.Map<CreatingTeamDto, Team>(creatingTeamDto);
            var creatingTeam = await _teamRepository.AddAsync(team);
            await _teamRepository.SaveChangesAsync();
            return creatingTeam.Id;
        }

        public async Task UpdateAsync(Guid id, UpdatingTeamDto updatingTeamDto)
        {
            var team = await _teamRepository.GetAsync(id, CancellationToken.None);
            if (team == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            team.TitleTeam = updatingTeamDto.TitleTeam;
            team.Founded = updatingTeamDto.Founded;
            _teamRepository.Update(team);
            await _teamRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var team = await _teamRepository.GetAsync(id, CancellationToken.None);
            if (team == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            _teamRepository.Delete(team);
            await _teamRepository.SaveChangesAsync();
        }

        public async Task<ICollection<TeamDto>> GetPagedAsync(int page, int pageSize)
        {
            ICollection<Team> entities = await _teamRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<Team>, ICollection<TeamDto>>(entities);
        }

        public async Task<ICollection<TeamDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            ICollection<Team> entities = await _teamRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<ICollection<Team>, ICollection<TeamDto>>(entities);
        }
    }
}
