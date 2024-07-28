using AutoMapper;
using CyberTech.Core.Dto.GameType;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Application.Services
{
    public class GameTypeService : IGameTypeService
    {

        private readonly IMapper _mapper;
        private readonly IGameTypeRepository _gameTypeRepository;

        public GameTypeService(IMapper mapper, IGameTypeRepository gameTypeRepository)
        {
            _mapper = mapper;
            _gameTypeRepository = gameTypeRepository;
        }

        public async Task<GameTypeDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var gameType = await _gameTypeRepository.GetAsync(id, CancellationToken.None);
            return _mapper.Map<Game, GameTypeDto>(gameType);
        }

        public async Task<Guid> CreateAsync(CreatingGameTypeDto creatingGameTypeDto)
        {
            var gameType = _mapper.Map<CreatingGameTypeDto, Game>(creatingGameTypeDto);
            var creatingGameType = await _gameTypeRepository.AddAsync(gameType);
            await _gameTypeRepository.SaveChangesAsync();
            return creatingGameType.Id;
        }

        public async Task UpdateAsync(Guid id, UpdatingGameTypeDto updatingGameTypeDto)
        {
            var gameType = await _gameTypeRepository.GetAsync(id, CancellationToken.None);
            if (gameType == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            gameType.TitleGame  = updatingGameTypeDto.TitleGame;
            gameType.Description = updatingGameTypeDto.Description;
            gameType.Category = updatingGameTypeDto.Category;
            gameType.ImageId = updatingGameTypeDto.ImageId;

            _gameTypeRepository.Update(gameType);
            await _gameTypeRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var gameType = await _gameTypeRepository.GetAsync(id, CancellationToken.None);
            if (gameType == null)
            {
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            }
            _gameTypeRepository.Delete(gameType);
            await _gameTypeRepository.SaveChangesAsync();
        }

        public async Task<ICollection<GameTypeDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            ICollection<Game> entities = await _gameTypeRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<ICollection<Game>, ICollection<GameTypeDto>>(entities);
        }
    }
}
