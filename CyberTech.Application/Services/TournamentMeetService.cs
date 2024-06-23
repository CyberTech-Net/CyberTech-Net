using AutoMapper;
using CyberTech.Core.Dto.TournamentMeet;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Domain.Entities;

namespace CyberTech.Application.Services
{
    public class TournamentMeetService : ITournamentMeetService
    {
        private readonly IMapper _mapper;
        private readonly ITournamentMeetRepository _tournamentMeetRepository;

        public TournamentMeetService(IMapper mapper, ITournamentMeetRepository tournamentMeetRepository)
        {
            _mapper = mapper;
            _tournamentMeetRepository = tournamentMeetRepository;
        }

        public async Task<TournamentMeetDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var tournamentMeet = await _tournamentMeetRepository.GetAsync(id, CancellationToken.None);
            return _mapper.Map<TournamentMeetEntity, TournamentMeetDto>(tournamentMeet);
        }

        public async Task<Guid> CreateAsync(CreatingTournamentMeetDto creatingTournamentMeetDto)
        {
            var tournamentMeet = _mapper.Map<CreatingTournamentMeetDto, TournamentMeetEntity>(creatingTournamentMeetDto);
            var creatingTournamentMeet = await _tournamentMeetRepository.AddAsync(tournamentMeet);
            await _tournamentMeetRepository.SaveChangesAsync();
            return creatingTournamentMeet.Id;
        }

        public async Task UpdateAsync(Guid id, UpdatingTournamentMeetDto updatingTournamentMeetDto)
        {
            var tournamentMeet = await _tournamentMeetRepository.GetAsync(id, CancellationToken.None);
            if (tournamentMeet == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            tournamentMeet.DataTournamentMeet = updatingTournamentMeetDto.DataTournamentMeet;
            tournamentMeet.TournamentId = updatingTournamentMeetDto.TournamentId;
            _tournamentMeetRepository.Update(tournamentMeet);
            await _tournamentMeetRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var tournamentMeet = await _tournamentMeetRepository.GetAsync(id, CancellationToken.None);
            if (tournamentMeet == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            _tournamentMeetRepository.Delete(tournamentMeet);
            await _tournamentMeetRepository.SaveChangesAsync();
        }

        public async Task<ICollection<TournamentMeetDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            ICollection<TournamentMeetEntity> entities = await _tournamentMeetRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<ICollection<TournamentMeetEntity>, ICollection<TournamentMeetDto>>(entities);
        }
    }
}
