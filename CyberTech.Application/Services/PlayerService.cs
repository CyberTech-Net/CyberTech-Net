using AutoMapper;
using CyberTech.Core.Dto.Player;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Domain.Entities;

namespace CyberTech.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IMapper _mapper;
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IMapper mapper, IPlayerRepository playerRepository)
        {
            _mapper = mapper;
            _playerRepository = playerRepository;
        }

        public async Task<PlayerDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var info = await _playerRepository.GetAsync(id, CancellationToken.None);
            return _mapper.Map<PlayerEntity, PlayerDto>(info);
        }

        public async Task<Guid> CreateAsync(CreatingPlayerDto creatingPlayerDto)
        {
            var player = _mapper.Map<CreatingPlayerDto, PlayerEntity>(creatingPlayerDto);
            var creatingPlayer = await _playerRepository.AddAsync(player);
            await _playerRepository.SaveChangesAsync();
            return creatingPlayer.Id;
        }

        public async Task UpdateAsync(Guid id, UpdatingPlayerDto updatingPlayerDto)
        {
            var player = await _playerRepository.GetAsync(id, CancellationToken.None);
            if (player == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            player.NickName = updatingPlayerDto.NickName;
            player.FirstName = updatingPlayerDto.FirstName;
            player.SecondName = updatingPlayerDto.SecondName;
            player.BirthDate = updatingPlayerDto.BirthDate;
            player.CountryId = updatingPlayerDto.CountryId;
            _playerRepository.Update(player);
            await _playerRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var player = await _playerRepository.GetAsync(id, CancellationToken.None);
            if (player == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            _playerRepository.Delete(player);
            await _playerRepository.SaveChangesAsync();
        }

        public async Task<ICollection<PlayerDto>> GetPagedAsync(int page, int pageSize)
        {
            ICollection<PlayerEntity> entities = await _playerRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<PlayerEntity>, ICollection<PlayerDto>>(entities);
        }

        public async Task<ICollection<PlayerDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            ICollection<PlayerEntity> entities = await _playerRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<ICollection<PlayerEntity>, ICollection<PlayerDto>>(entities);
        }

    }
}
